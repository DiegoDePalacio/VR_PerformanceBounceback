﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

public class Trampoline : MonoBehaviour
{
    public GameManager scoreScript = null;

#if UNITY_EDITOR
    [ContextMenu( "Assign the score script" )]
    private void AssignTheScoreScript()
    {
        scoreScript = FindObjectOfType<GameManager>();
        EditorSceneManager.MarkSceneDirty( EditorSceneManager.GetActiveScene() );
    }
#endif

    // Use this for initialization
    void Start ()
    {
        Assert.IsNotNull( scoreScript, "The score script in a Trampoline instance is not yet assigned!" );
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Throwable"))
        {
            //Particle effect
            ParticleSystemSpawner.current.SpawnParticleSystem( col.contacts[0].point );

            //Score Point
            scoreScript.AddOneToTheScore();
        }
    }
}
