using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using ExtensionMethods;

public class CameraFollow : MonoBehaviour {

    public Transform survivor;
    public float smoothing = 5;

	void Start ()
	{
        Assert.IsNotNull(survivor);
	}
	
	void FixedUpdate ()
	{
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, survivor.position.x, Time.deltaTime * smoothing),
                                         Mathf.Lerp(transform.position.y, survivor.position.y, Time.deltaTime * smoothing),
                                         transform.position.z);
	}
}
