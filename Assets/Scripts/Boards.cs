using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boards : MonoBehaviour
{
    private Transform[] boards;
    private float currentBoardHealth;
    public float BoardsMaxHealth;
    public int BoardsAlive { get; set; }
    public AudioSource auSourceOther, auSourceRepair;
    public AudioClip OnBoardPlaced, OnBoardDamage, OnBoardBreak;
    public float SFXAudioVolume;

    public bool IsRepairing { get; set; }
    private float lastRepair = 0f;
    public float RepairInterval;
    

    // Start is called before the first frame update
    void Start()
    {
        auSourceRepair.volume = SFXAudioVolume;

        boards = new Transform[transform.childCount];
        //get all boards and deactivate them to start with
        for(int i = 0; i < transform.childCount; i++)
        {
            boards[i] = transform.GetChild(i);
            //boards[i].gameObject.SetActive(false);
        }
        BoardsAlive = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsRepairing && Time.time - lastRepair > RepairInterval)
        {
            if(!auSourceRepair.isPlaying) { auSourceRepair.Play(); }
            RepairABoard();
        }
        else if(!IsRepairing && auSourceRepair.isPlaying) { auSourceRepair.Stop(); }
    }

    //repairs a single board when called
    private void RepairABoard()
    {
        if(BoardsAlive < boards.Length)
        {
            boards[BoardsAlive].gameObject.SetActive(true);
            auSourceOther.PlayOneShot(OnBoardPlaced, SFXAudioVolume);
            currentBoardHealth = BoardsMaxHealth;
            lastRepair = Time.time;
            BoardsAlive++;
            if(BoardsAlive >= boards.Length) //all fixed
            {
                IsRepairing = false;
            }
        }
    }

    //Called to do damage to boards
    public void TakeDamage(float damage)
    {
        if (BoardsAlive > 0)
        {
            currentBoardHealth -= damage; //doing damage to one board at a time
            if (currentBoardHealth <= 0f) //if the damage destroyed the board...
            {
                auSourceOther.PlayOneShot(OnBoardBreak, SFXAudioVolume);
                boards[BoardsAlive - 1].gameObject.SetActive(false); //...deactivate that board
                BoardsAlive--;
                if (BoardsAlive > 0)
                    currentBoardHealth = BoardsMaxHealth; //the next board has full health
            }
            else //didn't break just damaged
            {
                auSourceOther.PlayOneShot(OnBoardDamage, SFXAudioVolume);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        print("triggered");
        GameObject theEnemy = FindParentWithTag(other.gameObject, "Enemy");
        if (theEnemy != null)
        {
            print("enemy");
            theEnemy.GetComponent<Patrol>().attackstate = true;
        }
    }

    private static GameObject FindParentWithTag(GameObject childObject, string tag)
    {
        Transform t = childObject.transform;
        while (t.parent != null)
        {
            if (t.parent.tag == tag)
            {
                return t.parent.gameObject;
            }
            t = t.parent.transform;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            other.GetComponent<Patrol>().attackstate = true;
            print("triggered");
=======
>>>>>>> parent of 28e9378... aaa
=======
            
>>>>>>> 23e8da7d5adc7b28616e2cc7b88770d4f3fc978a
=======
            other.GetComponent<Patrol>().attackstate = true;
            print("triggered");
>>>>>>> parent of 6e7e398... vittu saatana
=======
            other.GetComponent<Patrol>().attackstate = true;
            print("triggered");
>>>>>>> parent of 6e7e398... vittu saatana
=======
            other.GetComponent<Patrol>().attackstate = true;
            print("triggered");
>>>>>>> parent of 6e7e398... vittu saatana
=======
            other.GetComponent<Patrol>().attackstate = true;
            print("triggered");
>>>>>>> parent of 6e7e398... vittu saatana
=======
            other.GetComponent<Patrol>().attackstate = true;
            print("triggered");
>>>>>>> parent of 6e7e398... vittu saatana
=======
            other.GetComponent<Patrol>().attackstate = true;
            print("triggered");
>>>>>>> parent of 6e7e398... vittu saatana
        }
        return null; // Could not find a parent with given tag.
    }
}
