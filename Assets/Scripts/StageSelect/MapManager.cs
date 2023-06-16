using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public SpriteRenderer sr; 
    public List<Sprite> maps = new List<Sprite>();
    private int mapRotation = 0;
    public static int selectedMap = 19;
    public GameObject map;

    public void NextOption() {
        mapRotation += 1;
        if (mapRotation == maps.Count) {
            mapRotation = 0;
        }
        sr.sprite = maps[mapRotation];
    }

    public void BackOption() {
        mapRotation -= 1;
        if (mapRotation < 0) {
            mapRotation = maps.Count - 1;
        }
        sr.sprite = maps[mapRotation];
    }

    public void PlayGame() {
        //switch scene over to fight
        selectedMap += mapRotation;
        SceneManager.LoadScene("Fight Scene");
    }
    
}