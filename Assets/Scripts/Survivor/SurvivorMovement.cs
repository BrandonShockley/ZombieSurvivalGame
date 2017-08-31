using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using ExtensionMethods;

public class SurvivorMovement : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;

    void Start ()
	{
        rb = this.GetRequiredComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
	{
        RotateToMouse();

        Move(Input.GetAxis("Vertical") * Vector2.up +
            Input.GetAxis("Horizontal") * Vector2.right);
    }

    void Move(Vector2 direction)
    {
        rb.velocity = direction.normalized * speed;
    }

    void Stop()
    {
        rb.velocity = Vector2.zero;
    }

    void RotateToMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 survivorToMouse = mousePos - (Vector2)transform.position;
        transform.rotation = survivorToMouse.ToZAxisRotation();
    }
}