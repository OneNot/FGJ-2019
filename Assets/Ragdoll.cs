using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{

    public bool ragdollNow = false;
    public float freezeDelay = 1;

    public Collider[] colliders;

    public Rigidbody[] extras;

    private float timePassed;
    private bool counting = false;



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

        if (counting)
        {
            timePassed += 1 * Time.deltaTime;
        }
        if (timePassed > freezeDelay)
        {
            foreach (Collider i in colliders)
            {
                counting = true;
                GetComponentInChildren<Animator>().enabled = false;
                i.GetComponent<Rigidbody>().isKinematic = true;
                i.GetComponent<Rigidbody>().useGravity = false;
            }

            foreach (Rigidbody i in extras)
            {
                i.GetComponent<Rigidbody>().isKinematic = true;
                i.GetComponent<Rigidbody>().useGravity = false;
            }
        }



    }


    public void ActivateRagdoll()
    {
        foreach (Collider i in colliders)
        {
            counting = true;
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