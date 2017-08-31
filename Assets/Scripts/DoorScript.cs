using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour, IShootable {

    Rigidbody2D body;
    HingeJoint2D hinge;

	void Start ()
	{
        body = GetComponent<Rigidbody2D>();
        hinge = GetComponent<HingeJoint2D>();
	}
	
	void Update ()
	{
		
	}

    public void OnShot(int damage)
    {
        Unlock();
    }

    private void Unlock()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
            body.constraints = RigidbodyConstraints2D.None;
            hinge.useLimits = false;
        }
    }
}
