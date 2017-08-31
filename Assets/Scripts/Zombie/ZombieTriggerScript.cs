using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTriggerScript : MonoBehaviour {
	
	void Start ()
	{
		
	}
	
	void Update ()
	{
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.parent.GetComponent<ZombieScript>().OnTriggerStay2D(collision);
    }
}
