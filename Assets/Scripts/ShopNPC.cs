using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ShopNPC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ulong playerID = other.gameObject.GetComponent<NetworkObject>().OwnerClientId;

            //Or Ownerclientid
            if(playerID == NetworkManager.Singleton.LocalClientId)
            {
                Debug.Log("Match");
            }
            else
            {
                Debug.Log("No Match");
            }
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
