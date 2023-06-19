using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charSelectOne : MonoBehaviour
{

    public static string selectedCharOneName;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void charOneSelect() {
        selectedCharOneName = "c" + gameObject.name.Substring(1);
        // Debug.Log(selectedCharOneName);
    }
}
