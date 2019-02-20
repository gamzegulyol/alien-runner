using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    // Use this for initialization
    public float moveSpeed;
    Animator animator;
    Rigidbody2D rb;
   // public Collider2D coll;

    void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        animator.SetTrigger("isWalking");

    }
}
