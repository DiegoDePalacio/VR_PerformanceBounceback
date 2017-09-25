using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ball
{
    public GameObject container = null;
    public Rigidbody rigidBody = null;
}

public class BallSpawner : MonoBehaviour {

    public static BallSpawner current;

    // If the number of ball is high, the manual assignation of the balls should be replaced
    // with the addition of another variable for the number of balls and a Context menu to
    // spawn in Editor time all the desired balls, filling automatically at the same time the 
    // values inside this List 
    public List<Ball> pooledBalls; //the object pool
    public static int ballPoolNum = 0; //a number used to cycle through the pooled objects

    private float cooldown;
    private float cooldownLength = 0.5f;

    void Awake()
    {
        current = this; //makes it so the functions in ObjectPool can be accessed easily anywhere
        foreach ( Ball ball in pooledBalls ) { ball.container.SetActive( false ); }
    }

    public Ball GetPooledBall()
    {
        ballPoolNum = ( ballPoolNum + 1 ) % pooledBalls.Count;
        return pooledBalls[ballPoolNum];
    }
   	
	// Update is called once per frame
	void Update ()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            cooldown = cooldownLength;
            SpawnBall();
        }		
	}

    void SpawnBall()
    {
        Ball selectedBall = BallSpawner.current.GetPooledBall();
        selectedBall.container.transform.position = transform.position;
        selectedBall.rigidBody.velocity = Vector3.zero;
        selectedBall.rigidBody.angularVelocity = Vector3.zero;
        selectedBall.container.SetActive(true);
    }
}