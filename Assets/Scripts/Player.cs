using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Audio
    public AudioSource source;
    public AudioClip attackClip;
    public AudioClip tookDamageClip;
    public AudioClip diedClip;
    public AudioClip jumpClip;


    //Camera Values
    public float yaw;
    public float pitch;
    public float mouseSensitivity;
    public Rigidbody body;


    public Camera playerCamera;
    public Attack attack;

    //Player Movement
    public float speed;
    public float jumpSpeed;
    public float gravityBoost;
    private Vector3 direction;

    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraControl();
        Move();
        Jump();
        Attack();
    }

    void FixedUpdate()
    {
        body.AddForce(Vector3.down * gravityBoost); 
    }

    void Move()
    {
        direction = new Vector3(0, 0, 0);

        if (Input.GetKey("w"))
        {
            direction += transform.forward;
        }
        if (Input.GetKey("s"))
        {
            direction += transform.forward * -1;
        }
        if (Input.GetKey("a"))
        {
            direction += transform.right * -1;
        }
        if (Input.GetKey("d"))
        {
            direction += transform.right;
        }




        transform.position += direction.normalized * speed * Time.deltaTime;

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            source.PlayOneShot(jumpClip);
            isGrounded = false;
            body.velocity += new Vector3(0, jumpSpeed, 0);
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            source.PlayOneShot(attackClip);
            StopAllCoroutines();
            StartCoroutine(AttackCoroutine());
        }

    }

    IEnumerator AttackCoroutine()
    {
        attack.Activate();
        yield return new WaitForSeconds(0.2f);
        attack.Deactivate();
    }

    void CameraControl()
    {
        yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");

        // Clamp pitch between lookAngle
        pitch = Mathf.Clamp(pitch, -80, 80);

        transform.localEulerAngles = new Vector3(0, yaw, 0);
        playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            source.PlayOneShot(tookDamageClip);
        }

        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }
}
