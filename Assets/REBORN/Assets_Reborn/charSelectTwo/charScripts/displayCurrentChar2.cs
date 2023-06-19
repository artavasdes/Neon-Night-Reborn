using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayCurrentChar2 : MonoBehaviour
{
    int charNum = -1;
    string name1;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<Button>().gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        name1 = charSelectTwo.selectedCharOneName;
        if (name1 != null) {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Button>().gameObject.SetActive(true);
            updateSelectedChar();
        }
        

    }

    void updateSelectedChar() {
        charNum = int.Parse(name1.Substring(1));
        Debug.Log(charNum);

        if (charNum != -1) {
            Debug.Log(Resources.Load("HighQualityCGs/Normal/" + charNum + "cg"));
           GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HighQualityCGs/Normal/" + charNum + "cg");
        }
    }
}
