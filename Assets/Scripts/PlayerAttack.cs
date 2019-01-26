using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 20f;
    private GameObject enemyTarget;
    private bool enemyInRange;
    public GameObject equippedWeapon;
    public List<GameObject> Weapons;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (equippedWeapon != null && GetComponentInChildren<WeaponBehavior>() != null)
        {
            if (Input.GetButtonDown("Fire1") && GetComponentInChildren<WeaponBehavior>().AnimationsPlaying(0) == false && gameObject.GetComponent<Grabber>().objectGrabbed == false && GetComponentInChildren<WeaponInfo>().type == "melee")
            {
                GetComponentInChildren<WeaponBehavior>().PlayWeaponAnimation();
                if (enemyInRange == true)
                {
                    enemyTarget.GetComponent<EnemyHealth>().health -= damage;
                }
            }
        }

        if (equippedWeapon != null)
        {
            if (Input.GetButtonDown("Fire1") && gameObject.GetComponent<Grabber>().objectGrabbed == false && GetComponentInChildren<WeaponInfo>().type == "shotgun")
            {
                GetComponentInChildren<Bullet_Spawner_Shotgun>().fire();
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") >= 0.1)
        {
            NextWeapon();
        }

        if (Input.GetAxis("Mouse ScrollWheel") <= -0.1)
        {
            PrevWeapon();
        }

        //print(Input.GetAxis("Mouse ScrollWheel"));
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

    public void SwitchToWeapon(GameObject weapon)
    {
        UnEquipWeapon();
        equippedWeapon = weapon;
        EquipWeapon();
    }

    public void EquipWeapon()
    {
        equippedWeapon.SetActive(true);
    }

    public void UnEquipWeapon()
    {
        equippedWeapon.SetActive(false);
    }

    public void NextWeapon()
    {
        if(Weapons[Weapons.IndexOf(equippedWeapon)] != Weapons[Weapons.Count -1])
        {
            SwitchToWeapon(Weapons[Weapons.IndexOf(equippedWeapon) + 1]);
        }

        else
            SwitchToWeapon(Weapons[0]);
    }

    public void PrevWeapon()
    {
        if (Weapons[Weapons.IndexOf(equippedWeapon)] != Weapons[0])
        {
            SwitchToWeapon(Weapons[Weapons.IndexOf(equippedWeapon) - 1]);
        }

        else
            SwitchToWeapon(Weapons[Weapons.Count - 1]);
    }
}
