using System.Collections;
using System.Collections.Generic;
// Patrol.cs
using UnityEngine;
using UnityEngine.AI;


public class Patrol : MonoBehaviour
{
    private float last_attack_time = 0f;
    public float attackspeed;
    private Transform target;
    private NavMeshAgent agent;
    public bool attackstate;
    public float attackdamage;
    public Animator animator;

    void Start()
    {
        attackstate = false;
        agent = GetComponent<NavMeshAgent>(); 

        GameObject[] windows = GameObject.FindGameObjectsWithTag("Window"); //finds all gameobjects with the tag window attached to them and lists them as boards
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door"); //finds all gameobjects with the tag window attached to them and lists them as boards
        GameObject[] entrances = new GameObject[windows.Length + doors.Length];
        for(int i = 0; i < windows.Length; i++)
        {
            entrances[i] = windows[i];

        }                                                                   //
        for(int i = 0; i < doors.Length; i++)                               //creates an array out of the windows and doors
        {                                                                   //
            entrances[windows.Length + i] = doors[i];

        }


        Transform closest_entrance = entrances[0].transform; //the first entrance on the list is then made the closest entrance to compare all the other boards to

        float closest_entrance_distance = Vector3.Distance(entrances[0].transform.position, transform.position); //evaluates the distance of the closest entrance

        foreach (GameObject entrance in entrances) //loops through all the other possibilities
        {
            if(Vector3.Distance(entrance.transform.position, transform.position)<closest_entrance_distance) //compares the other entrances distances with the closest entrance distance
            {
                closest_entrance = entrance.transform;
                closest_entrance_distance = Vector3.Distance(entrance.transform.position, transform.position);
         
            }
        }
        target = closest_entrance; //claims the closest entrance as the target

        
        
    }
    void Update()
    {
        if (!attackstate)
        {
            animator.isMoving = true;
            agent.destination = target.position;
        }
        else if(Time.time - last_attack_time > attackspeed)
        {
            animator.isMoving = false;
            animator.atWindow = animator.atDoor = false;
            if(target.tag == "Door")
            {
                animator.atDoor = true;
                //if (target.GetComponent<DoorScript>().Health > 0f)
                {
                    //target.GetComponent<DoorScript>().TakeDamage(attackdamage);
                }
                //else { GoInside(); }
            }
            else if(target.tag == "Window")
            {
                animator.atWindow = true;
                if (target.GetComponent<Boards>().BoardsAlive > 0)
                {
                    target.GetComponent<Boards>().TakeDamage(attackdamage);
                }
                else { GoInside(); }
            }
            else
            {
                //player attack animation
                //target.GetComponent<PlayerStatus>().TakeDamage(attackdamage);
            }
            last_attack_time = Time.time;
        }

    }
    
    private void GoInside()
    {
        attackstate = false;
        //go inside animation
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

}