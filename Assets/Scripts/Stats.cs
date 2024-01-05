using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private float rhealth;
    private float rspeed;
    private float rjumpSpeed;
    private float rpower;
    private int goldCount;

    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float power;


    public int GetGold()
    {
        return goldCount;
    }

    public void AddGold()
    {
        goldCount += 10;
    }

    public void SetGold(int goldCount)
    {
        this.goldCount = goldCount;
    }

    public float GetHealth()
    {
        return health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetJumpSpeed()
    {
        return jumpSpeed;
    }

    public void SetJumpSpeed(float jumpSpeed)
    {
        this.jumpSpeed = jumpSpeed;
    }

    public void ResetHealth()
    {
        health = rhealth;
    }
    public void ResetSpeed()
    {
        speed = rspeed;
    }
    public void ResetJumpSpeed()
    {
        jumpSpeed = rjumpSpeed;
    }
    public float GetPower()
    {
        return power;
    }

    public void SetPower(float power)
    {
        this.power = power;
    }


    // Start is called before the first frame update
    void Start()
    {
        rhealth = health;
        rspeed = speed;
        rjumpSpeed = jumpSpeed;
        rpower = power;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
