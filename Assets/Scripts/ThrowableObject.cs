using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public float damage = 20;

    //onnistuuko heitto
    public bool canBeThrown = true;

    //tekeekö damagea, eli esim kun pelaaja on heittänyt sen
    public bool primed = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<EnemyHealth>() != null && primed == true)
        {
            col.gameObject.GetComponent<EnemyHealth>().health -= damage;
            primed = false;
        }

        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<ThrowableObject>() == null && GetComponentInParent<Grabber>() != null && col.gameObject.GetComponent<PlayerMovement>()==null)
        {
            //print("hellou");
            GetComponentInParent<Grabber>().detachObject();
        }
    }


}
