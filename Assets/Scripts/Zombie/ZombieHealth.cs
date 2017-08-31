using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour, IShootable {

    private int health;

    public void OnShot(int damage)
    {
        health -= damage;
    }

    void Start ()
	{
		
	}
	
	void Update ()
	{
        if (health <= 0)
            Destroy(gameObject);
	}
}
