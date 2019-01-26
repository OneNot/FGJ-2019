using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD_HP_Bar : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sen sijaan että käyttää updatea, voisi päivittää HP baria joka kerta kun ottaa damagea. Mut ei ehkä jakseta säätää damage sourcejen kanssa. T. Zen Hege

        if (player == null)
            gameObject.GetComponent<Slider>().value = GameObject.Find("PlayerSimulatorV2").GetComponent<PlayerStatus>().Health;

        else
            gameObject.GetComponent<Slider>().value = player.GetComponent<PlayerStatus>().Health;


    }
}
