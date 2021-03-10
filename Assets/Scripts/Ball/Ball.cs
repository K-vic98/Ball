using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private int _score;

    public event UnityAction<int> ScoreChanged;

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        SceneManager.LoadScene("MainMenu");
    }
}