﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class WeaponBehavior : MonoBehaviour
{
    public List<string> animations;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AnimationsPlaying(int layer)
    {
        foreach(string a in animations)
        {
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(layer).IsName(a))
            {
                return true;
            }
        }

        return false;
    }

    private string RandomWeaponAnimation()
    {
        int tester = Random.Range(0, animations.Count);
        //print(tester);

        return animations[tester];
    }

    public void PlayWeaponAnimation()
    {
        gameObject.GetComponent<Animator>().Play(RandomWeaponAnimation(), 0, 0f);
    }
}
