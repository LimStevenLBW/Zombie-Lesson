using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class PlayerCanvas : NetworkBehaviour
{
    public GameOverScreen gameOverScreen;
    public PlayerHealthBar healthBar;
    public TextMeshProUGUI goldCounter;
    public TextMeshProUGUI playerCount;

    private NetworkVariable<int> playerNum = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    public override void OnNetworkSpawn()
    {
        playerNum.OnValueChanged += UpdatePlayerCountText;
    }
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       if(IsServer) playerNum.Value = NetworkManager.Singleton.ConnectedClients.Count;
    }

    public void UpdatePlayerCountText(int previous, int newValue)
    {
        playerCount.SetText("Players: " + newValue.ToString());
    }

    public void SetHealthBar(float health)
    {
        healthBar.SetHealthBar(health);
    }


    public void ShowGameOverScreen()
    {
        gameOverScreen.gameObject.SetActive(true);
    }

    public void UpdateGoldCounterText(int goldCount)
    {
        goldCounter.SetText(goldCount.ToString());
    }

}
