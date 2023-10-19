using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour, Attackable
{
    private bool isActive;
    private Coroutine isDyingCoroutine;
    public Stats zombieStats;
    public AudioSource source;
    public AudioClip tookDamageClip;
    public AudioClip diedClip;

    public float forceAmount;

    private Player target;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == false) return;

        if(zombieStats.GetHealth() <= 0)
        {
            isActive = false;

            if (isDyingCoroutine == null) isDyingCoroutine = StartCoroutine(Dedge());

        }

        direction = target.transform.position - transform.position;
        transform.position += direction.normalized * zombieStats.GetSpeed() * Time.deltaTime;

        //Storing the rotation towards the player
        Vector3 rotation = Quaternion.LookRotation(target.transform.position - transform.position).eulerAngles;

        rotation.x = 0;
        rotation.z = 0;
        transform.rotation = Quaternion.Euler(rotation);
    }

    IEnumerator Dedge()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {

    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player" && isActive)
        {
            Rigidbody body = other.gameObject.GetComponent<Rigidbody>();
            Vector3 liftOffset = new Vector3(0, 0.2f, 0);

            Vector3 impactDirection = target.transform.position - transform.position;

            body.AddForce((impactDirection + liftOffset) * forceAmount);
        }

    }

    //This is what happens when the zombie is attacked
    public void Attacked(float playerForceAmount, Vector3 forceDirection, float power)
    {
        //Zombie takes damage
        zombieStats.TakeDamage(power);


        Rigidbody body = GetComponent<Rigidbody>();
        Vector3 liftOffset = new Vector3(0, 0.2f, 0);
        body.AddForce((forceDirection + liftOffset) * playerForceAmount);
    }
}
