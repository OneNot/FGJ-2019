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
    public float moveCloser = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //Täällä kehotetaan tekemään fysiikkajutut
    private void LateUpdate()
    {
        

        if (Input.GetButtonDown("Fire2") && objectGrabbed == false && grabbableObject.GetComponent<ThrowableObject>().canBeThrown == true && objectInRange == true)
        {
            
            grabbableObject.transform.SetParent(gameObject.transform);
            //grabbableObject.transform.rotation = gameObject.transform.rotation;
            grabbableObject.GetComponent<Rigidbody>().useGravity = false;
            grabbableObject.GetComponent<Rigidbody>().isKinematic = true;
            //grabbableObject.transform.position = new Vector3(grabbableObject.transform.position.x, gameObject.transform.position.y, grabbableObject.transform.position.z);
            grabbedObject = grabbableObject.transform.gameObject;
            //grabbableObject.transform.position = Vector3.MoveTowards(grabbableObject.transform.position, gameObject.transform.position, moveCloser);
            gameObject.GetComponent<PlayerAttack>().UnEquipWeapon();
            objectGrabbed = true;
        }

        else if (Input.GetButtonDown("Fire1") && objectGrabbed == true)
        {
            detachObject();

            grabbedObject.GetComponent<ThrowableObject>().primed = true;
            grabbedObject.GetComponent<Rigidbody>().AddForce(transform.forward * force);

            gameObject.GetComponent<PlayerAttack>().EquipWeapon();
        }

        else if (Input.GetButtonDown("Fire2") && objectGrabbed == true)
        {
            detachObject();

            gameObject.GetComponent<PlayerAttack>().EquipWeapon();
        }
    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.GetComponent<ThrowableObject>() != null)
        {
            grabbableObject = obj.gameObject;
            objectInRange = true;
        }

    }

    private void OnTriggerExit(Collider obj)
    {
        objectInRange = false;

    }

    public void detachObject()
    {
        grabbedObject.transform.SetParent(null);

        
        grabbedObject.GetComponent<Rigidbody>().useGravity = true;
        grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        
        objectGrabbed = false;

        print("detached");

        gameObject.GetComponent<PlayerAttack>().EquipWeapon();

    }
}
