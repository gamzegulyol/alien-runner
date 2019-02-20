using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPoint : MonoBehaviour {

    private int score=5;

    private ScoreManager scoreManager;


	void Start () {

        scoreManager = FindObjectOfType<ScoreManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            scoreManager.scoreCount += score;

            gameObject.SetActive(false);
        }


    }

}
