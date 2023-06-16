using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyAudio : MonoBehaviour
{
    [SerializeField]
    private GameObject audioObj;

    void Awake(){
        audioObj.AddComponent<AudioSource>();
        AudioSource audioComponent = audioObj.GetComponent<AudioSource>();
        audioComponent.clip = Resources.Load<AudioClip>("Audio/mainmenumusic");
        audioComponent.loop = true;
        audioComponent.Play();

        // Scene currentScene = SceneManager.GetActiveScene ();
        // string sceneName = currentScene.name;
        // if(sceneName == "CharacterSelection"){
        //     DontDestroyOnLoad(transform.gameObject);
        // }
        // else if(sceneName == "CharactersView"){
        //     DontDestroyOnLoad(transform.gameObject);
        // }
        // else if(sceneName == "MainMenu"){
        //     DontDestroyOnLoad(transform.gameObject);
        // }
        // else{
        //     Destroy(transform.gameObject);
        // }
        
    }
}
