using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Stats playerStats;

    //Audio
    public AudioSource source;
    public AudioClip attackClip;
    public AudioClip tookDamageClip;
    public AudioClip diedClip;
    public AudioClip jumpClip;


    public Transform rotatorJoint;
    //Camera Values
    public float yaw;
    public float pitch;
    public float mouseSensitivity;
    public Rigidbody body;

    public Camera playerCamera;
    public Attack attack;

    //Player Movement
    public float gravityBoost;
    private Vector3 direction;

    private bool isGrounded;
    private bool isDashing;

    private Coroutine DashCoroutine;
    private Coroutine AttackCoroutine;

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

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && !isDashing)
        {
            if (DashCoroutine != null) StopCoroutine(DashCoroutine);

            isDashing = true;
            DashCoroutine = StartCoroutine(Dashing(direction));
            //StartCoroutine(Rolling(direction));
        }


        if (!isDashing) transform.position += direction.normalized * playerStats.GetSpeed() * Time.deltaTime;

    }
    IEnumerator Rolling(Vector3 direction)
    {
        /*
        float time = 0;
        while(time < 1)
        {
            transform.position = Vector3.Slerp(transform.position, transform.position + direction, time);

            time += Time.deltaTime * speed * 5;
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);
        */

        // Vector3 rotation = transform.rotation.eulerAngles;
        //rotation.y += 90;
        //rotatorJoint.localRotation = Quaternion.Euler(rotation);
        

        for (int i = 0; i < 360; i++)
        {
            rotatorJoint.Rotate(direction.normalized, Space.Self);
            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator Dashing(Vector3 direction)
    {
       //Dashing
       body.AddForce(direction.normalized * 1500);
       yield return new WaitForSeconds(0.3f);

       //Slow down the character
       body.velocity *= 0.5f;
       body.angularVelocity *= 0.5f;

       //Regular movement becomes available
       isDashing = false;

       //Cooldown 
       yield return new WaitForSeconds(0.2f);

    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            source.PlayOneShot(jumpClip);
            isGrounded = false;
            body.velocity += new Vector3(0, playerStats.GetJumpSpeed(), 0);
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
  
            if (AttackCoroutine != null) StopCoroutine(AttackCoroutine);

            AttackCoroutine = StartCoroutine(Attacking());

        }

    }

    IEnumerator Attacking()
    {
        source.PlayOneShot(attackClip);
        attack.Activate(playerStats.GetPower());
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
