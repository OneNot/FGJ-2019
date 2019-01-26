using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        print("Dickbutt");
        if (other.tag == "Enemy")
        {
            Debug.Log("Bullshit");
            other.GetComponent<Patrol>().playerTrigger = transform.GetComponent<PlayerTrigger>();
        }
    }
}
