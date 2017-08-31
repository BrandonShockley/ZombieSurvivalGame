using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    LineRenderer lr;

    public float trailDuration;
    
    public int damage;

    float counter;
	void Start ()
	{

        
	}
	
	void Update ()
	{
        //Fade
        counter += Time.deltaTime;
        Gradient gradient = new Gradient();
        gradient.colorKeys = lr.colorGradient.colorKeys;
        gradient.SetKeys(lr.colorGradient.colorKeys, 
            new GradientAlphaKey[] { new GradientAlphaKey((trailDuration - counter) / 1f, 0), new GradientAlphaKey(0, 1) });
        lr.colorGradient = gradient;

        if (counter > trailDuration)
            Destroy(gameObject);
	}
}
