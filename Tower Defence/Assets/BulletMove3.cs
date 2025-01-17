﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletMove3 : MonoBehaviour
{
    public GameObject target = null;
    private float times;
    public TowerContribute2 scripts = null;
    public Enemy scripts1 = null;
    public Tower_Attack3 attack1;
    void Start()
    {
        times = 0;
    }

    void Update()
    {
        times += Time.deltaTime;
        if (times <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * 15);
        Attack();
    }

    private void Attack()
    {
        if (target != null)
        {
            //Debug.Log(Vector3.Distance(transform.position, target.transform.position));
            if (Vector3.Distance(transform.position, target.transform.position) < 1.1f) //if bullet and target close less than 0.5f
            {
                if (scripts1.Hp == scripts.AttackAbility)
                {
                    scripts1.modifHP(scripts.AttackAbility);
                    attack1.enemy.Remove(scripts1.gameObject);
                    Destroy(gameObject);
                }
                else
                {
                    scripts1.modifHP(scripts.AttackAbility);
                    Destroy(gameObject);
                }
            }
        }
        else
        {   
            //destroy it self if no one to attack
            Destroy(gameObject);
        }
    }
}
