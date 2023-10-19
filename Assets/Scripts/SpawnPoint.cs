using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour, Attackable
{
    public GameObject obj;
    public GameObject spawnArea;
    public float rateOfSpawn;
    public bool isAutomatic;


    // Start is called before the first frame update
    void Start()
    {
        if(isAutomatic) StartCoroutine(Spawn());


    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(rateOfSpawn);

            Instantiate(obj, transform.position, Quaternion.identity);

        }
      

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && spawnArea)
        {
            Instantiate(obj, spawnArea.transform.position, Quaternion.identity);
        }
    }

    public void Attacked(float playerForceAmount, Vector3 forceDirection, float power)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
