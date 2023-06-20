using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject parentCanvas;
    public string chosenCharacter1 = charSelectOne.selectedCharOneName; 
    public string chosenCharacter2 = charSelectTwo.selectedCharOneName; 
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    public static int won = 0; 

    void Start(){
        // PlayerIcon1(); // load icon 1
        // Player1Char(); 
        CharSet(); 
        HeaderSet(); 
    }

    public void Update(){ 
        GameEnd(); 
    }


    void CharSet(){ 
        // player 1 animation set 
        string path1 = "Animation/" + 13 + "_animation/" + 13; 
        Animator animator1 = player1.GetComponent<Animator>(); 
        animator1.runtimeAnimatorController = Resources.Load(path1) as RuntimeAnimatorController;

        // player 2 animation set 
        string path2 = "Animation/" + chosenCharacter2 + "_animation/" + chosenCharacter2; 
        Animator animator2 = player1.GetComponent<Animator>(); 
        animator2.runtimeAnimatorController = Resources.Load(path2) as RuntimeAnimatorController;
    }


    void HeaderSet(){  
        string cgPath = "Headshots/char_" + 13 + "_icon";
        Texture2D CG = Resources.Load<Texture2D>(cgPath);
        Sprite cgSprite = Sprite.Create(CG, new Rect(0.0f, 0.0f, CG.width, CG.height), new Vector2(0f, 0f), 100.0f);

        GameObject HeaderUI = parentCanvas.transform.GetChild(2).gameObject;
        GameObject Player1UI = HeaderUI.transform.GetChild(0).gameObject;
        GameObject HealthBar1 = Player1UI.transform.GetChild(0).gameObject;
        GameObject Border = HealthBar1.transform.GetChild(0).gameObject;
        GameObject PlayerIcon = Border.transform.GetChild(0).gameObject;
        GameObject icon = PlayerIcon.transform.GetChild(0).gameObject;
        icon.GetComponent<Image>().sprite = cgSprite;
    }

    void GameEnd(){ 
        if (won == 0){
            return; 
        }
        else if (won == 1){ 
            _winScreen.SetActive(true); 
        }
    }
}
