using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject parentCanvas;
    public int chosenCharacter = AltCharacterDisplay.chosenCharacter; 
    public GameObject player1; 
    void Awake(){
        PlayerIcon1(); // load icon 1
        Player1Char(); 
    }

    void PlayerIcon1(){
        string cgPath = "Headshots/char_" + chosenCharacter + "_icon";
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

    void Player1Char(){
        string cgPath = "Animation/" + chosenCharacter + "_animation/" + chosenCharacter; 
        Animator animator = player1.GetComponent<Animator>(); 
        animator.runtimeAnimatorController = Resources.Load(cgPath) as RuntimeAnimatorController;

    }
}
