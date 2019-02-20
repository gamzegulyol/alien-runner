using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    // Use this for initialization
    public GameObject ground;
    public Transform generationPoint;
    private float platformWidth;


    void Start () {
        platformWidth = ground.GetComponent<BoxCollider2D>().size.x;
	}
	// Update is called once per frame
	void Update () {
		
        if(transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth, transform.position.y, transform.position.z);

          Destroy(Instantiate(ground, transform.position, transform.rotation),20);
        }



    }
}
