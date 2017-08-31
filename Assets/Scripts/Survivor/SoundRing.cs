using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRing : MonoBehaviour {

    public float expansionRadius;
    float counter;

	void Start ()
	{
        counter = 0;
	}
	
	void Update ()
	{
        counter += Time.deltaTime * 100;
        transform.localScale = new Vector2(counter, counter);
        if (counter > expansionRadius * 2)
            Destroy(gameObject);
	}
}
