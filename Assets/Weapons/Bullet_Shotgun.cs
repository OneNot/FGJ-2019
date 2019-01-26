using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Shotgun : MonoBehaviour
{
    public float damage = 5;
    public float lifetime = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        
        if(col.gameObject.GetComponent<EnemyHealth>()!= null)
        {
            col.gameObject.GetComponent<EnemyHealth>().health -= damage;
            Destroy(gameObject);
        }

        
       
    }
}
