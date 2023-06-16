using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void characterViewSceneChange(){
        SceneManager.LoadScene("CharactersView");
    }
    public void connectionSceneChange(){
        SceneManager.LoadScene("ConnectionScene");
    }
    public void characterSelectionSceneChange(){
        //SceneManager.LoadScene("CharacterSelection");
        SceneManager.LoadScene("altcharselect");
    }
}
