using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameManager gameManager = null;

	// Use this for initialization
	void Start ()
    {
        Assert.IsNotNull( gameManager, "GameManager is not yet assigned!" );
	}
	
	// Update is called once per frame
	void Update ()
    {
        Text text = GetComponentInChildren<Text>();
        text.text = "Score: " + gameManager.score.ToString();
	}
}
