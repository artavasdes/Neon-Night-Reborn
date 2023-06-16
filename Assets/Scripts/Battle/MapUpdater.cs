using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject mapImage;
    void Awake()
    {
        Debug.Log("Audio/Stages/map_" + MapManager.selectedMap +"_resized");
        mapImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Stages/map_" + MapManager.selectedMap +"_resized");
    }
}
