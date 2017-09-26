using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Trampoline : MonoBehaviour {

    public ParticleSystem pSystem;
    public GameManager scoreScript = null;

	// Use this for initialization
	void Start ()
    {
        Assert.IsNotNull( scoreScript, "The score script in a Trampoline instance is not yet assigned!" );
    }

    // Update is called once per frame
    void Update ()
    {
        pSystem = GetComponentInChildren<ParticleSystem>();
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Throwable"))
        {
            //Score Point
            scoreScript.score++;
            //Particle effect
            pSystem.Play();

            Debug.Log("Trampoline Hit");
        }

    }
}
