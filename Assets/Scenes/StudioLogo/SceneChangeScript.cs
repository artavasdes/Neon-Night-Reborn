using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        FadeToLevel();
    }

    public void FadeToLevel(){
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete(){
        SceneManager.LoadScene("StartScreen");
    }
}
