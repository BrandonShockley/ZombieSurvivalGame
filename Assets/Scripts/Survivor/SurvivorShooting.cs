using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;

public class SurvivorShooting : MonoBehaviour {

    public float soundRange;
    public int damage;
    public float shotInterval;
    public float accuracy;
    public float shotRange;

    private LineRenderer lr;

    private float shotTimer = 0;

    void Start()
    {
        lr = this.GetRequiredComponent<LineRenderer>();
    }

    void FixedUpdate ()
	{
        shotTimer += Time.deltaTime;
        if (Input.GetAxis("Fire1") > 0 && shotTimer > shotInterval)
            Shoot();
	}

    void Shoot()
    {
        RaycastHit2D result = Physics2D.Raycast(transform.position, transform.rotation * Vector2.right, shotRange);

        IShootable[] shootables = result.collider.GetComponents<IShootable>();
        if (shootables != null)
            foreach (IShootable shootable in shootables)
                shootable.OnShot(damage);

        //Use result to draw line
        lr.SetPositions(new Vector3[] { transform.position, transform.position + (transform.rotation * Vector2.right) * 
                                                            (result.distance > 0 ? result.distance : shotRange)
        });

        shotTimer = 0;
    }


}
