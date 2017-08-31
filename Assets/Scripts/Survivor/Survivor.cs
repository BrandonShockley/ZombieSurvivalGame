using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Survivor : MonoBehaviour {

    public float healthLostPerSecond;
    public float healthLostPerShot;
    public float maxHealth;
    public Transform soundRingPrefab;
    public AudioClip shotSound;
    public Slider healthBar;

    Rigidbody2D body;
    AudioSource audio;
    float shotCooldown;
    float health;
    public float Health
    {
        set
        {
            health = value > maxHealth ? maxHealth : value;
            healthBar.value = health;
            if (health <= 0)
            {
                GameObject.Find("YouDied").GetComponent<SpriteRenderer>().enabled = true;
                DontDestroyOnLoad(GameObject.Find("YouDied"));
                SceneManager.LoadScene(0);
            }
        }
        get
        {
            return health;
        }
    }

	void Start ()
	{
        healthBar = FindObjectOfType<Slider>();
        healthBar.maxValue = maxHealth;
        Health = maxHealth;
        audio = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();
        shotCooldown = 0;
	}
	
	void Update ()
	{
        shotCooldown += Time.deltaTime;
        Health -= healthLostPerSecond * Time.deltaTime;
	}

    /*void Shoot()
    {
        

        //Alert nearby zombies
        foreach (ZombieScript zombie in FindObjectsOfType<ZombieScript>())
        {
            Vector2 fromZombie = zombie.transform.position - transform.position;
            if (fromZombie.magnitude <= soundRange)
                zombie.AlertLocation(transform.position);
        }

        //Create sound ring
        Transform ring = Instantiate<Transform>(soundRingPrefab, transform.position, new Quaternion());
        ring.GetComponent<SoundRing>().expansionRadius = soundRange;

        //Loose health
        Health -= healthLostPerShot;
    }*/
}
