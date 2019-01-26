using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        print("Dickbutt");
        if (other.tag == "Enemy")
        {
            Debug.Log("Bullshit");
            other.GetComponent<Patrol>().doorTrigger = transform.GetComponent<DoorTrigger>();
        }
    }
}
