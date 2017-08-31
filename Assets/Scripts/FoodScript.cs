using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour {

    AudioSource audio;
    public float healthRestored;

	void Start ()
	{
        audio = GetComponent<AudioSource>();
	}
	
	void Update ()
	{
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Survivor>().Health += healthRestored;
            AudioClip clip = Resources.Load<AudioClip>("Sounds/Eat");
            audio.PlayOneShot(clip);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, clip.length);
        }
    }
}
