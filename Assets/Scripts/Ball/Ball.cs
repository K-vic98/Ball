using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private int _score;
    private const string NameOfMenuScene = "MainMenu";

    public event UnityAction<int> ScoreChanged;

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        SceneManager.LoadScene(NameOfMenuScene);
    }
}