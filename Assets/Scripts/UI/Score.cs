using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _ball.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _ball.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }
}