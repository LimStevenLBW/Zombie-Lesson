using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;


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
