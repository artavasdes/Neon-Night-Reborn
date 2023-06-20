using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainToChar : MonoBehaviour
{
    Animator anim;
    
    
    // Start is called before the first frame update

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    public void mainToCharScene()
    {
        Application.LoadLevel("InputSelect");
    }

    public void mainClean() {
        anim.SetTrigger("clean");
    }
}
