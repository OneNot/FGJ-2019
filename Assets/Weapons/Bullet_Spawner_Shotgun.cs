using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Spawner_Shotgun : MonoBehaviour
{

    public Rigidbody bullet;
    public float randomSpread;
    public float velocity;
    public int pellets;
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
        //print("fired");

        for (int i = 0; i < pellets; i++)
        {
            Rigidbody instantiatedProjectile = Instantiate(bullet,
                                                                            transform.position,
                                                                            transform.rotation)
                                 as Rigidbody;

            RandomizePos(instantiatedProjectile);
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(Random.Range(randomSpread-1,randomSpread), Random.Range(randomSpread - 1, randomSpread), velocity));
            
        }

        //Asteroidipelin peruja... tästä äänet sitku on
        /*AudioSource audio = GetComponent<AudioSource>();
        audio.PlayDelayed(0f);
        audio.Play(44100);*/
    }

    void RandomizePos(Rigidbody obj)
    {
        obj.transform.Translate(Vector3.right * Random.Range(randomSpread * -1, randomSpread));
        obj.transform.Translate(Vector3.up * Random.Range(randomSpread * -1, randomSpread));

        //rot
    }

    
}
