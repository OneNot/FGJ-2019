using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Gravity, MoveSpeed, LookSensitivity, VerticalLookAngleLimit, PushForce;
    private float VerRotation, HorRotation;
    private Transform playerCam;
    private CharacterController controller;
    private AudioSource auSource;
    public AudioClip footS1, footS2, footS3;

    public GameObject tempBoardTarget;

    // Start is called before the first frame update
    void Start()
    {
        auSource = GetComponent<AudioSource>();
        auSource.volume = PlayerPrefs.GetInt("SFX", 50) / 100;
        controller = transform.GetComponent<CharacterController>();
        playerCam = transform.Find("Main Camera");
        VerRotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //calculate rotations
        HorRotation = transform.eulerAngles.y + Input.GetAxis("Mouse X") * LookSensitivity;
        VerRotation += Input.GetAxis("Mouse Y") * LookSensitivity;
        VerRotation = Mathf.Clamp(VerRotation, -VerticalLookAngleLimit, VerticalLookAngleLimit);

        //apply rotations
        transform.eulerAngles = new Vector3(0f, HorRotation, 0f); //apply horizontal rotation to player
        playerCam.localEulerAngles = new Vector3(-VerRotation, 0f, 0f); //apply vertical rotation to camera only

        //Get movement inputs
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * MoveSpeed;

        //add gravity
        moveDirection.y -= Gravity * Time.deltaTime;

        //apply movement
        controller.Move(moveDirection * Time.deltaTime);

        //Debug code=====
        /*if(Input.GetButtonUp("Fire1"))
        {
            tempBoardTarget.GetComponent<Boards>().TakeDamage(10f);
        }
        if(Input.GetButtonDown("Fire2"))
        {
            tempBoardTarget.GetComponent<Boards>().IsRepairing = true;
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            tempBoardTarget.GetComponent<Boards>().IsRepairing = false;
        }*/
        //================
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        // no rigidbody
        if (body == null || body.isKinematic)
            return;

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3)
            return;

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // Apply the push
        body.AddForceAtPosition(pushDir * PushForce / body.mass, hit.point); //BUG: moving sideways while pushing makes pushing MUCH easier...
    }

    public void PlayFootstepAudio()
    {
        float ran = Random.Range(0f, 1f);
        if(ran < 0.333f)
        {
            auSource.PlayOneShot(footS1);
        }
        else if(ran < 0.666)
        {
            auSource.PlayOneShot(footS2);
        }
        else
        {
            auSource.PlayOneShot(footS3);
        }
    }
}
