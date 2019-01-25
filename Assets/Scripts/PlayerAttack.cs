using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 20f;
    private GameObject enemyTarget;
    private bool enemyInRange;
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (weapon != null && GetComponentInChildren<WeaponBehavior>() != null)
        {
            if (Input.GetButtonDown("Fire1") && GetComponentInChildren<WeaponBehavior>().AnimationsPlaying(0) == false && gameObject.GetComponent<Grabber>().objectGrabbed == false)
            {
                GetComponentInChildren<WeaponBehavior>().PlayWeaponAnimation();
                if (enemyInRange == true)
                {
                    enemyTarget.GetComponent<EnemyHealth>().health -= damage;
                }
            }
        }
        /*
        if(enemyTarget != null)
        print(enemyTarget.name);*/
    }

    private void OnTriggerStay(Collider enemy)
    {
        if (enemy.GetComponent<EnemyHealth>() != null)
        {
            enemyTarget = enemy.gameObject;
            enemyInRange = true;
        }
    }

    private void OnTriggerExit(Collider enemy)
    {
        if (enemy.GetComponent<EnemyHealth>() != null)
        {
            enemyInRange = false;
        }
    }
}
