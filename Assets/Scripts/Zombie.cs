using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public AudioSource source;
    public AudioClip tookDamageClip;
    public AudioClip diedClip;

    public float speed;
    public float forceAmount;

    private Player target;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        transform.forward = direction;

    }

    // Update is called once per frame
    void Update()
    {
        direction = target.transform.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

    }

    void FixedUpdate()
    {
        //Storing the rotation towards the player
        Vector3 rotation = Quaternion.LookRotation(target.transform.position).eulerAngles;

        rotation.x = 0;
        rotation.z = 0;
        transform.rotation = Quaternion.Euler(rotation);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rigidbody body = other.gameObject.GetComponent<Rigidbody>();
            Vector3 liftOffset = new Vector3(0, 0.2f, 0);

            Vector3 impactDirection = target.transform.position - transform.position;

            body.AddForce((impactDirection + liftOffset) * forceAmount);
        }

    }

}
