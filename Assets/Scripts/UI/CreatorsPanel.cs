using UnityEngine;

public class CreatorsPanel : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void ClosePanel()
    {
        _animator.SetBool(AnimatorCreatorsPanel.Params.IsOpen, false);
    }
}