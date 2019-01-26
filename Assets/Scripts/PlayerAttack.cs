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

    public bool SwitchToWeapon(GameObject weapon)
    {
        if (weapon.GetComponentInChildren<WeaponInfo>().unlocked == true)
        {
            UnEquipWeapon();
            equippedWeapon = weapon;
            EquipWeapon();
            return true;
        }

        else
            return false;
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
        int counter = 1;

        if(Weapons[Weapons.IndexOf(equippedWeapon)] != Weapons[Weapons.Count -1])
        {
            for(int i = 0;i<Weapons.Count; i++)

            if(SwitchToWeapon(Weapons[Weapons.IndexOf(equippedWeapon) + counter]) == true)
            {
                    i = Weapons.Count;
            }

            counter++;
        }

        else
            SwitchToWeapon(Weapons[0]);
    }

    public void PrevWeapon()
    {
        int counter = -1;

        if (Weapons[Weapons.IndexOf(equippedWeapon)] != Weapons[Weapons.Count - 1])
        {
            for (int i = 0; i < Weapons.Count; i++)

                if (SwitchToWeapon(Weapons[Weapons.IndexOf(equippedWeapon) - counter]) == true)
                {
                    i = Weapons.Count;
                }

            counter--;
        }

        else
            SwitchToWeapon(Weapons[Weapons.Count - 1]);
    }
}
