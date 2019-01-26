using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Spawner_Shotgun : MonoBehaviour
{

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fire()
    {
        Instantiate(bullet,transform.gameObject)
    }
}
