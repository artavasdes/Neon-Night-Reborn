using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject parentCanvas;
    public string chosenCharacter1;
    public string chosenCharacter2; 
    [SerializeField] private GameObject _winScreen1;
    [SerializeField] private GameObject _winScreen2;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player1_icon;
    [SerializeField] private GameObject player2_icon;


    public static int won = 0; 
    private bool timer1 = false;

    void Start(){
        // PlayerIcon1(); // load icon 1
        // Player1Char(); 
        // Debug.Log(chosenCharacter1);
        chosenCharacter1 = charSelectOne.selectedCharOneName.Substring(1); 
        chosenCharacter2 = charSelectTwo.selectedCharOneName.Substring(1); 

        CharSet(); 
        HeaderSet(); 
        Timer.TimerOn = true; 
    }

    public void Update(){ 
        GameEnd(); 
        if (timer1 == false) {
            StartCoroutine(myTimer());
        }
    }


    void CharSet(){ 

        player1.SetActive(true); 
        player2.SetActive(true); 

        if (1 == int.Parse(chosenCharacter1) || 2 == int.Parse(chosenCharacter1)){
            Debug.Log("transform");
            player1.transform.localScale += new Vector3(3,3,0); 
        }
        if (1 == int.Parse(chosenCharacter2) || 2 == int.Parse(chosenCharacter2)){ 
            Debug.Log("transform");
            player2.transform.localScale += new Vector3(3,3,0); 
        }

        // player 1 animation set 
        string path1 = "Animation/" + chosenCharacter1 + "_animation/" + chosenCharacter1; 
        Animator animator1 = player1.GetComponent<Animator>(); 
        animator1.runtimeAnimatorController = Resources.Load(path1) as RuntimeAnimatorController;

        // player 2 animation set 
        string path2 = "Animation/" + chosenCharacter2 + "_animation/" + chosenCharacter2; 
        Animator animator2 = player2.GetComponent<Animator>(); 
        animator2.runtimeAnimatorController = Resources.Load(path2) as RuntimeAnimatorController;
    }


    void HeaderSet(){  
        Debug.Log(chosenCharacter1);
        string cgPath = "Headshots/char_" + chosenCharacter1 + "_icon";
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

        cgPath = "Headshots/char_" + chosenCharacter2 + "_icon";
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
        else if (won == 2){ 
            _winScreen1.SetActive(true); 
            Debug.Log("Player 1 wins!"); 
        }
        else if (won == 1){ 
            _winScreen2.SetActive(true); 
            Debug.Log("Player 2 wins!"); 

        }
        else if (Timer.GameOver == true){
            _winScreen1.SetActive(true); 
            Debug.Log("Game Tied!"); 
        }


        
        Invoke("load", 5);
        won = 0;
        
    }

    IEnumerator myTimer()
    {

        timer1 = true;
        yield return new WaitForSeconds(10);
        timer1 = false;

    }

    void load(){
        Application.LoadLevel("MainMenuReborn");
    }
}
