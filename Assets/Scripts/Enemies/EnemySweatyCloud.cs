﻿using UnityEngine;
using System.Collections;

public class EnemySweatyCloud : EnemyBaseController {

    // the maximum movement speed the virus can go at, which is chosen from randomly
    public float randomHorizontalMovementMax = 0.5f;
    public float randomVerticalMovementMax = 0.5f;
    // how long it moves for before random movement is reset
    public float changeDirectionTime = 10f;

    // temporary variables, used to set the random movement
    float currentHorizontalMovement;
    float currentVerticalMovement;

    public override void Start()
    {
        base.Start();
        StartCoroutine("RandomMovement");
    }
    
    void Update()
    {
        Movement();
    }

    public override void Movement()
    {
        base.Movement();
        rb.velocity = new Vector2(currentHorizontalMovement, currentVerticalMovement + playerRb.velocity.y);
    }

    // randomly chooses an x and y movement speed, then resets after chaingeDirectionTime
    IEnumerator RandomMovement()
    {
        currentHorizontalMovement = Random.Range(-randomHorizontalMovementMax, randomHorizontalMovementMax);
        currentVerticalMovement = Random.Range(-randomVerticalMovementMax, -randomVerticalMovementMax);        
        yield return new WaitForSeconds(changeDirectionTime);
        StartCoroutine("RandomMovement");
    }
}
