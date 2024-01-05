using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCanvas : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public PlayerHealthBar healthBar;
    public TextMeshProUGUI goldCounter;
    public Shop shop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowShop()
    {
        shop.gameObject.SetActive(true);
    }

    public void HideShop()
    {
        shop.gameObject.SetActive(false);
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
