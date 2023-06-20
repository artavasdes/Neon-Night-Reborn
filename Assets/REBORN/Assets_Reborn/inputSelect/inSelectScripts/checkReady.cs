using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkReady : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (gameObject.transform.Find("inputDisplay").GetChild(5).gameObject.active) {
            if (gameObject.transform.Find("inputDisplay2").GetChild(5).gameObject.active) {
                Application.LoadLevel("CharSelect");
            }
        }

    }
}
