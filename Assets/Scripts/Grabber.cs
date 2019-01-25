using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public float force = 1;
    public bool objectGrabbed;
    private GameObject grabbedObject;
    private bool objectInRange;
    private GameObject grabbableObject;
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(grabbableObject.name);

       
    }

    //Täällä kehotetaan tekemään fysiikkajutut
    private void LateUpdate()
    {
        if (Input.GetButtonDown("Fire2") && objectGrabbed == false && grabbableObject.GetComponent<ThrowableObject>().canBeThrown == true && objectInRange == true)
        {
            objectGrabbed = true;
            grabbableObject.transform.SetParent(gameObject.transform);
            grabbableObject.transform.rotation = gameObject.transform.rotation;
            grabbableObject.GetComponent<Rigidbody>().useGravity = false;
            grabbableObject.transform.position = new Vector3(grabbableObject.transform.position.x, gameObject.transform.position.y, grabbableObject.transform.position.z);
            grabbedObject = grabbableObject.transform.gameObject;

            weapon.SetActive(false);
        }

        else if (Input.GetButtonDown("Fire2") && objectGrabbed == true)
        {
            detachObject();

            grabbedObject.GetComponent<Rigidbody>().AddForce(transform.forward * force);

            weapon.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider obj)
    {
        grabbableObject = obj.gameObject;
        objectInRange = true;

    }

    private void OnTriggerExit(Collider obj)
    {
        objectInRange = false;

    }

    public void detachObject()
    {
        objectGrabbed = false;
        grabbedObject.transform.SetParent(null);
        grabbedObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
