using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float forceAmount;

    private bool active;
    private MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        mesh.enabled = true;
        active = true;
    }

    public void Deactivate()
    {
        mesh.enabled = false;
        active = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && active)
        {
            Rigidbody body = other.gameObject.GetComponent<Rigidbody>();
            Vector3 liftOffset = new Vector3(0, 0.2f, 0);
            body.AddForce((transform.forward + liftOffset) * forceAmount);
            Deactivate();
        }

    }
}
