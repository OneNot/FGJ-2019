using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float MaxHealth;
    public float Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0f)
        {
            //ded.
            print("Game Over");
        }
    }
}
