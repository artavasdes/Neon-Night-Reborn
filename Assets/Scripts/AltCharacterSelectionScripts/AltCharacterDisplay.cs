using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AltCharacterDisplay : MonoBehaviour
{    
    [SerializeField]
    public GameObject ParentPanel;
    public static Dictionary<GameObject, int> altCharactersDictionary = new Dictionary<GameObject, int>();
    public static int chosenCharacter;
    public static List<Dictionary<string, float>> charactersList = new List<Dictionary<string, float>>();

    void Awake(){
        populateDictionary();
        if(CheckNFTOwner.validAddress == false){
            for(int i = 0; i < 14; i++){
                string cgPath = "Headshots/char_" + i + "_icon";
                Texture2D CG = Resources.Load<Texture2D>(cgPath);
                Sprite cgSprite = Sprite.Create(CG, new Rect(0.0f, 0.0f, CG.width, CG.height), new Vector2(0f, 0f), 100.0f);
                GameObject button = ParentPanel.transform.GetChild(i).gameObject;
                Button buttonClick = button.AddComponent<Button>();
                buttonClick.transform.SetParent(ParentPanel.transform);
                buttonClick.onClick.AddListener(() => OnClick(button));
                button.GetComponent<Image>().sprite = cgSprite;
                
                if(i == 13){
                    button.GetComponent<Button>().interactable = true;
                }
                else{
                    button.GetComponent<Button>().interactable = false;
                }
                altCharactersDictionary.Add(button,i);
            }
        }
        else{
            for(int i = 0; i < 14; i++){
                if(i == 13){
                    string cgPath = "Headshots/char_" + i + "_icon";
                    Texture2D CG = Resources.Load<Texture2D>(cgPath);
                    Sprite cgSprite = Sprite.Create(CG, new Rect(0.0f, 0.0f, CG.width, CG.height), new Vector2(0f, 0f), 100.0f);
                    GameObject button = ParentPanel.transform.GetChild(i).gameObject;
                    Button buttonClick = button.AddComponent<Button>();
                    buttonClick.transform.SetParent(ParentPanel.transform);
                    buttonClick.onClick.AddListener(() => OnClick(button));
                    button.GetComponent<Image>().sprite = cgSprite;
                    button.GetComponent<Button>().interactable = true;
                    altCharactersDictionary.Add(button,i);
                }
                else if(CheckNFTOwner.ownerDic[i] == true){
                    string cgPath = "Headshots/char_" + i + "_icon";
                    Texture2D CG = Resources.Load<Texture2D>(cgPath);
                    Sprite cgSprite = Sprite.Create(CG, new Rect(0.0f, 0.0f, CG.width, CG.height), new Vector2(0f, 0f), 100.0f);
                    GameObject button = ParentPanel.transform.GetChild(i).gameObject;
                    Button buttonClick = button.AddComponent<Button>();
                    buttonClick.transform.SetParent(ParentPanel.transform);
                    buttonClick.onClick.AddListener(() => OnClick(button));
                    button.GetComponent<Image>().sprite = cgSprite;
                    button.GetComponent<Button>().interactable = true;
                    altCharactersDictionary.Add(button,i);                   
                }
                else{
                    string cgPath = "Headshots/char_" + i + "_icon";
                    Texture2D CG = Resources.Load<Texture2D>(cgPath);
                    Sprite cgSprite = Sprite.Create(CG, new Rect(0.0f, 0.0f, CG.width, CG.height), new Vector2(0f, 0f), 100.0f);
                    GameObject button = ParentPanel.transform.GetChild(i).gameObject;
                    Button buttonClick = button.AddComponent<Button>();
                    buttonClick.transform.SetParent(ParentPanel.transform);
                    buttonClick.onClick.AddListener(() => OnClick(button));
                    button.GetComponent<Image>().sprite = cgSprite;
                    button.GetComponent<Button>().interactable = false;
                    altCharactersDictionary.Add(button,i);
                }
            }
        }
    }

    public void OnClick(GameObject characterObject){
        int characterId = altCharactersDictionary[characterObject];
        Debug.Log("Clicked: " + characterId);
        chosenCharacter = characterId;
        SceneManager.LoadScene(sceneName:"ConnectionScene");
    }

    private void populateDictionary(){
        for(int i = 0; i < 14; i++){
            Dictionary<string, float> characterStatsDictionary = new Dictionary<string, float>();
            if(i == 0){
                characterStatsDictionary.Add("Health", 7000f);
                characterStatsDictionary.Add("Attack", 350f);
                characterStatsDictionary.Add("Defense", 0.2f);
            }
            else if(i == 1){
                characterStatsDictionary.Add("Health", 7500f);
                characterStatsDictionary.Add("Attack", 325f);
                characterStatsDictionary.Add("Defense", 0.3f);
            }
            else if(i == 2){
                characterStatsDictionary.Add("Health", 6500f);
                characterStatsDictionary.Add("Attack", 350f);
                characterStatsDictionary.Add("Defense", 0.225f);
            }
            else if(i == 3){
                characterStatsDictionary.Add("Health", 7000f);
                characterStatsDictionary.Add("Attack", 325f);
                characterStatsDictionary.Add("Defense", 0.3f);
            }
            else if(i == 4){
                characterStatsDictionary.Add("Health", 5250f);
                characterStatsDictionary.Add("Attack", 400f);
                characterStatsDictionary.Add("Defense", 0.2f);
            }
            else if(i == 5){
                characterStatsDictionary.Add("Health", 8500f);
                characterStatsDictionary.Add("Attack", 400f);
                characterStatsDictionary.Add("Defense", 0.075f);
            }
            else if(i == 6){
                characterStatsDictionary.Add("Health", 7500f);
                characterStatsDictionary.Add("Attack", 315f);
                characterStatsDictionary.Add("Defense", 0.25f);
            }
            else if(i == 7){
                characterStatsDictionary.Add("Health", 5500f);
                characterStatsDictionary.Add("Attack", 400f);
                characterStatsDictionary.Add("Defense", 0.3f);
            }
            else if(i == 8){
                characterStatsDictionary.Add("Health", 6500f);
                characterStatsDictionary.Add("Attack", 375f);
                characterStatsDictionary.Add("Defense", 0.25f);
            }
            else if(i == 9){
                characterStatsDictionary.Add("Health", 4500f);
                characterStatsDictionary.Add("Attack", 550f);
                characterStatsDictionary.Add("Defense", 0.1f);
            }
            else if(i == 10){
                characterStatsDictionary.Add("Health", 6250f);
                characterStatsDictionary.Add("Attack", 375f);
                characterStatsDictionary.Add("Defense", 0.25f);
            }
            else if(i == 11){
                characterStatsDictionary.Add("Health", 11250f);
                characterStatsDictionary.Add("Attack", 250f);
                characterStatsDictionary.Add("Defense", 0.3f);
            }
            else if(i == 12){
                characterStatsDictionary.Add("Health", 10000f);
                characterStatsDictionary.Add("Attack", 500f);
                characterStatsDictionary.Add("Defense", 0.35f);
            }
            else if(i == 13){
                characterStatsDictionary.Add("Health", 5000f);
                characterStatsDictionary.Add("Attack", 300f);
                characterStatsDictionary.Add("Defense", 0.2f);
            }
            charactersList.Add(characterStatsDictionary);
        }   
        foreach(var x in charactersList) {
            foreach (KeyValuePair<string, float> kvp in x)
                Debug.Log("Key = {0}, Value = {1}" + kvp.Key + kvp.Value);
        }
    }
}
