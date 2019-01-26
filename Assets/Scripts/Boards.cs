using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boards : MonoBehaviour
{
    private Transform[] boards;
    private float currentBoardHealth;
    public float BoardsMaxHealth;
    public int BoardsAlive { get; set; }
    

    // Start is called before the first frame update
    void Start()
    {
        boards = new Transform[transform.childCount];
        //get all boards and deactivate them to start with
        for(int i = 0; i < transform.childCount; i++)
        {
            boards[i] = transform.GetChild(i);
            boards[i].gameObject.SetActive(false);
        }
        BoardsAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //repairs a single board when called
    public void RepairABoard()
    {
        if(BoardsAlive < boards.Length)
        {
            boards[BoardsAlive].gameObject.SetActive(true);
            currentBoardHealth = BoardsMaxHealth;
            BoardsAlive++;
        }
    }

    //Called to do damage to boards
    public void TakeDamage(float damage)
    {
        if (BoardsAlive > 0)
        {
            currentBoardHealth -= damage; //doing damage to one board at a time
            if(currentBoardHealth <= 0f) //if the damage destroyed the board...
            {
                boards[BoardsAlive - 1].gameObject.SetActive(false); //...deactivate that board
                BoardsAlive--;
                if(BoardsAlive > 0)
                    currentBoardHealth = BoardsMaxHealth; //the next board has full health
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {

            other.GetComponent<Patrol>().attackstate = true;
        }
    }
}
