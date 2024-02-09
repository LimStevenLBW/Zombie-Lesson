using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    private Player activePlayer;

    public List<ShopItem> items;

    // Start is called before the first frame update
    void Start()
    {
        foreach(ShopItem item in items)
        {
            item.SetPlayer(activePlayer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
