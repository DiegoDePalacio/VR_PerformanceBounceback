using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameManager gameManager = null;

    // Replace this for an array if more than one text should be handled by this component
    public Text text = null;

	// Use this for initialization
	void Start ()
    {
        Assert.IsNotNull( gameManager, "GameManager is not yet assigned!" );
        Assert.IsNotNull( text, "The Score text is not yet assigned!" );
	}
	
	// Update is called once per frame
	void Update ()
    {
        text.text = "Score: " + gameManager.score.ToString();
	}
}
