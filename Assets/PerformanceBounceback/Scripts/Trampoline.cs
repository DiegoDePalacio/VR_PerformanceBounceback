using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Trampoline : MonoBehaviour
{
    public ParticleSystem pSystem = null;
    public GameManager scoreScript = null;

#if UNITY_EDITOR
    [ContextMenu( "Assign the score script" )]
    private void AssignTheScoreScript()
    {
        scoreScript = FindObjectOfType<GameManager>();
        EditorUtility.SetDirty( this );
    }
#endif

    // Use this for initialization
    void Start ()
    {
        Assert.IsNotNull( scoreScript, "The score script in a Trampoline instance is not yet assigned!" );
        Assert.IsNotNull( pSystem, "The particle system in a Trampoline instance is not yet assigned!" );
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Throwable"))
        {
            //Score Point
            scoreScript.AddOneToTheScore();
            //Particle effect
            pSystem.Play();

            Debug.Log("Trampoline Hit");
        }
    }
}
