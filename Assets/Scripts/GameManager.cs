using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class GameManager : NetworkBehaviour
{
    public Player playerPrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    public static GameManager instance { get; private set; }

    private int numberOfPlayers;
    private Player player1;
    private Player player2;

    public override void OnNetworkSpawn()
    {
        if (!IsServer) return;

        if (NetworkManager.Singleton)
        {
            NetworkManager.Singleton.OnClientConnectedCallback += NewPlayerConnected;
        }

        base.OnNetworkSpawn();
    }

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void NewPlayerConnected(ulong playerID)
    {
        if (IsServer)
        {
            numberOfPlayers++;

            if (numberOfPlayers == 1)
            {
                player1 = Instantiate(playerPrefab, spawnPoint1.position, Quaternion.identity);
                player1.GetComponent<NetworkObject>().SpawnAsPlayerObject(playerID);
                
            }
            else if(numberOfPlayers == 2)
            {
                player2 = Instantiate(playerPrefab, spawnPoint2.position, Quaternion.identity);
                player2.GetComponent<NetworkObject>().SpawnAsPlayerObject(playerID);
            }
        }
    }

    public Player GetPlayer1()
    {
        return player1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
