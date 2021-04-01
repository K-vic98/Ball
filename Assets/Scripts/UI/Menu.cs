using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] Animator _creatorsPanel;

    private const string NameOfGameScene = "Game";

    public void StartGame()
    {
        SceneManager.LoadScene(NameOfGameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowPanel()
    {
        _creatorsPanel.SetBool(AnimatorCreatorsPanel.Params.IsOpen, true);
    }
}