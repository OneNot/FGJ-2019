using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public enum Gender { Male, Female }
    public enum EnemyType { Neighbor, Ex, Jevohah, Postman, Taxman, Police, Kopla }
    public EnemyType enemyType { get; private set; }
    public Gender gender { get; private set; }
    public float MaxHealth;
    public float Health { get; set; }
    public float Attackspeed;
    public float AttackDamage;


    // Start is called before the first frame update
    void Start()
    {
        enemyType = EnemyType.Neighbor;
        gender = Random.Range(0f, 1f) >= 0.5 ? Gender.Male : Gender.Female; //50-50% gender randomization
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
