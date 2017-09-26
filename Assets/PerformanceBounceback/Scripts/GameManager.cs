using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score;
    public Action<int> OnScoreChanged = null;

    public void AddOneToTheScore()
    {
        score++;
        if ( OnScoreChanged != null )
        {
            OnScoreChanged( score );
        }
    }
}
