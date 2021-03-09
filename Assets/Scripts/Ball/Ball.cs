using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    private int _score;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction PlayerDied;

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {

    }
}