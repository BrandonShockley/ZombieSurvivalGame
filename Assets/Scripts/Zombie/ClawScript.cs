using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawScript : MonoBehaviour {

    public float duration;

    float counter;

	void Start ()
	{
        counter = 0;
	}
	
	void Update ()
	{
        counter += Time.deltaTime;
        if (counter > duration)
            Destroy(gameObject);
	}
}
