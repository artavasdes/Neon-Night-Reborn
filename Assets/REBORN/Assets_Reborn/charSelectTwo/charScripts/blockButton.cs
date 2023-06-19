using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blockButton : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "b" + charSelectOne.selectedCharOneName.Substring(1)) {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
