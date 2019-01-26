using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{

    public bool ragdollNow = false;

    public Collider[] colliders;

    public Rigidbody[] extras;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ragdollNow)
        {
            ActivateRagdoll();
        }
            


    }


    public void ActivateRagdoll()
    {
        foreach(Collider i in colliders)
            {
            GetComponentInChildren<Animator>().enabled = false;
            i.GetComponent<Rigidbody>().isKinematic = false;
            i.GetComponent<Rigidbody>().useGravity = true;
        }

        foreach (Rigidbody i in extras)
        {
            i.GetComponent<Rigidbody>().isKinematic = false;
            i.GetComponent<Rigidbody>().useGravity = true;
        }

    }



}
