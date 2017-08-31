using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour {
	
	public void StartGame()
    {
        GameObject surv = GameObject.Find("YouSurvived");
        GameObject ded = GameObject.Find("YouDied");
        if (surv != null)
            GameObject.Find("YouSurvived").GetComponent<SpriteRenderer>().enabled = false;
        if (ded != null)
            GameObject.Find("YouDied").GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Start");
        SceneManager.LoadScene(1);
    }
}
