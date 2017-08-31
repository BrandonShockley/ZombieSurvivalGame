using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour {

    public float damage;
    public float health;
    public float speed;
    public float groanInterval;
    public float attackInterval;
    public Transform clawPrefab;

    Grid grid;
    Rigidbody2D body;
    AudioSource audio;

    Vector2 lastKnownLocation;

    float groanCounter;
    float attackCounter;

	void Start ()
	{
        groanCounter = 0;
        grid = FindObjectOfType<Grid>();
        body = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
	}
	
	void Update ()
	{
        attackCounter += Time.deltaTime;
        groanCounter += Time.deltaTime + Random.Range(-.5f, .5f);
        if (groanCounter > groanInterval)
        {
            Groan();
            groanCounter = 0;
        }
        Stop();
        if (CanSeeSurvivor())
            lastKnownLocation = FindObjectOfType<Survivor>().transform.position;
        if (lastKnownLocation != null)
            FindPath(lastKnownLocation);
    }

    public void Damage(int damage)
    {
        health -= damage;
    }

    void FindPath(Vector2 position)
    {
        Point gridPos = grid.WorldToGrid(position);

        if (gridPos != null)
        {
            if (gridPos.X > 0 && gridPos.Y > 0 && gridPos.X < grid.Width && gridPos.Y < grid.Height)
            {
                Point zombiePos = grid.WorldToGrid(transform.position);

                BreadCrumb bc = PathFinder.FindPath(grid, zombiePos, gridPos);

                if (bc != null)
                {
                    body.velocity = (Grid.GridToWorld(bc.next.position) - (Vector2)transform.position).normalized * speed;
                    transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(body.velocity.y, body.velocity.x));
                }
            }
        }
    }

    void Stop()
    {
        body.velocity = Vector2.zero;
    }

    void Groan()
    {
        float rand = Random.value;
        //Debug.Log(rand > .5f);
        AudioClip clip = rand > .5f ? Resources.Load<AudioClip>("Sounds/zombieLong1") : 
                                                Resources.Load<AudioClip>("Sounds/zombieLong2");
        audio.PlayOneShot(clip);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && attackCounter > attackInterval)
        {
            Attack();
            attackCounter = 0;
        }
    }

    void Attack()
    {
        float rand = Random.value;
        //Debug.Log(rand > .5f);
        AudioClip clip = rand > .5f ? Resources.Load<AudioClip>("Sounds/zombieHurt1") :
                                                Resources.Load<AudioClip>("Sounds/zombieHurt2");
        audio.PlayOneShot(clip);
        FindObjectOfType<Survivor>().Health -= damage;
        Instantiate<Transform>(clawPrefab, transform);
    }

    bool CanSeeSurvivor()
    {
        Vector2 survivorPos = FindObjectOfType<Survivor>().transform.position;
        Vector2 fromSurvivor = (Vector2)transform.position - survivorPos;
        RaycastHit2D result = Physics2D.Raycast(survivorPos, fromSurvivor.normalized, fromSurvivor.magnitude);
        return result.collider.gameObject == gameObject;
    }

    public void AlertLocation(Vector2 position)
    {
        lastKnownLocation = position;
    }
}
