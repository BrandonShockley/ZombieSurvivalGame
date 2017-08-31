using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour {

    Text text;

	void Start ()
	{
        text = GetComponent<Text>();
	}
	
	void Update ()
	{
        int zombiesRemaining = GameObject.FindGameObjectsWithTag("Zombie").Length;
        text.text = "Zombies Remaining\n" + zombiesRemaining;

        if (zombiesRemaining == 0)
        {
            GameObject.Find("YouSurvived").GetComponent<SpriteRenderer>().enabled = true;
            DontDestroyOnLoad(GameObject.Find("YouSurvived"));
            SceneManager.LoadScene(0);
        }
	}
}
