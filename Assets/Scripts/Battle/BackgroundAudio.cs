using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject audioObj;
    void Awake()
    {
        Debug.Log("Audio start");
        Debug.Log(MapManager.selectedMap);
        audioObj.AddComponent<AudioSource>();
        AudioSource audioComponent = audioObj.GetComponent<AudioSource>();
        audioComponent.clip = Resources.Load<AudioClip>("Audio/StageAudio/map_" + MapManager.selectedMap);
        //AudioSource audioBack = Resources.Load<AudioSource>("Audio/StageAudio/map_" + MapManager.selectedMap);
        Debug.Log("Audio load");
        audioComponent.volume = 0.1f;
        audioComponent.loop = true;
        audioComponent.Play();
        Debug.Log("Audio end");
    }

    void Update(){
        if(Timer.GameOver == true){
            AudioSource audioComponent = audioObj.GetComponent<AudioSource>();
            audioComponent.Stop();
        }
    }
}
