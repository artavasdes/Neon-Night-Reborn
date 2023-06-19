using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainToChar : MonoBehaviour
{
    // Start is called before the first frame update
    public void mainToCharScene()
    {
        Application.LoadLevel("CharSelect");
    }
}
