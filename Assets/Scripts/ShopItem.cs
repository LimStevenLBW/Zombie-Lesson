using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public Weapon weapon;
    public Player player;

    public void Buy()
    {
        int playerMoney = player.playerStats.GetGold();
        int cost = weapon.cost;

        if(playerMoney >= cost)
        {
            player.weaponController.Equip(weapon);
            playerMoney -= cost;
            player.playerStats.SetGold(playerMoney);
        }

    }

    public void SetItemInfo(string name, int cost)
    {
        nameText.SetText(name);

        string c = cost + " Gold";
        costText.SetText(c);
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
