using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        print("Dickbutt");
        if (other.tag == "Enemy")
        {
            Debug.Log("Bullshit");
            other.GetComponent<Patrol>().windowTrigger = transform.GetComponent<WindowTrigger>();
        }
    }
}
