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
    [SerializeField] private GameObject player1_icon;
    [SerializeField] private GameObject player2_icon;

    public static int won = 0; 

    void Start(){
        // PlayerIcon1(); // load icon 1
        // Player1Char(); 
        CharSet(); 
        HeaderSet(); 
        Timer.TimerOn = true; 
    }

    public void Update(){ 
        GameEnd(); 
    }


    void CharSet(){ 

        player1.SetActive(true); 
        player2.SetActive(true); 

        // player 1 animation set 
        string path1 = "Animation/" + 1 + "_animation/" + 1; 
        Animator animator1 = player1.GetComponent<Animator>(); 
        animator1.runtimeAnimatorController = Resources.Load(path1) as RuntimeAnimatorController;

        // player 2 animation set 
        string path2 = "Animation/" + 0 + "_animation/" + 0; 
        Animator animator2 = player1.GetComponent<Animator>(); 
        animator2.runtimeAnimatorController = Resources.Load(path2) as RuntimeAnimatorController;
    }


    void HeaderSet(){  
        string cgPath = "Headshots/char_" + 13 + "_icon";
        Texture2D CG = Resources.Load<Texture2D>(cgPath);
        Sprite cgSprite = Sprite.Create(CG, new Rect(0.0f, 0.0f, CG.width, CG.height), new Vector2(0f, 0f), 100.0f);

        // GameObject HeaderUI = parentCanvas.transform.GetChild(2).gameObject;
        // GameObject Player1UI = HeaderUI.transform.GetChild(0).gameObject;
        // GameObject HealthBar1 = Player1UI.transform.GetChild(0).gameObject;
        // GameObject Border = HealthBar1.transform.GetChild(0).gameObject;
        // GameObject PlayerIcon = Border.transform.GetChild(0).gameObject;
        // GameObject icon = PlayerIcon.transform.GetChild(0).gameObject;
        player1_icon.GetComponent<Image>().sprite = cgSprite;
        player1_icon.SetActive(true); 

        cgPath = "Headshots/char_" + 12 + "_icon";
        CG = Resources.Load<Texture2D>(cgPath);
        cgSprite = Sprite.Create(CG, new Rect(0.0f, 0.0f, CG.width, CG.height), new Vector2(0f, 0f), 100.0f);

        // GameObject Player2UI = HeaderUI.transform.GetChild(1).gameObject;
        // GameObject HealthBar2 = Player2UI.transform.GetChild(0).gameObject;
        // GameObject Border2 = HealthBar2.transform.GetChild(0).gameObject;
        // GameObject PlayerIcon2 = Border2.transform.GetChild(0).gameObject;
        // GameObject icon2 = PlayerIcon2.transform.GetChild(0).gameObject;
        player2_icon.GetComponent<Image>().sprite = cgSprite;
        player2_icon.SetActive(true); 

    }

    void GameEnd(){ 
        if (won == 0){
            return; 
        }
        else if (won == 1){ 
            _winScreen.SetActive(true); 
            Debug.Log("Player 1 wins!"); 
        }
        else if (won == 2){ 
            _winScreen.SetActive(true); 
            Debug.Log("Player 2 wins!"); 

        }
        else if (Timer.GameOver == true){
            _winScreen.SetActive(true); 
            Debug.Log("Game Tied!"); 

        }
    }
}
