using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    public void OnButtonPress(){
      SceneManager.LoadScene("REBORN/Scenes/MainMenu");
      Debug.Log("ja");
   }

}
