using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EthereumWallettInputScript : MonoBehaviour
{
    public string walletAddress;
    [SerializeField]
    public TextMeshProUGUI validMessageChange;
    public Dictionary<Sprite, Sprite> imageSprites = new Dictionary<Sprite, Sprite>();
    [SerializeField]
    public GameObject ParentPanel;
    public List<GameObject> objectsList = new List<GameObject>();

    public async void ReadStringInput(string s){
        if(s.Length == 42){
            Debug.Log("Valid Address");
            walletAddress = s;

            await CheckNFTOwner.CheckOwner(walletAddress);

            Debug.Log("count" + CheckNFTOwner.ownerDic.Count);

            foreach (KeyValuePair<int, bool> kvp in CheckNFTOwner.ownerDic)
                Debug.Log("Key = {0}, Value = {1}" + kvp.Key + kvp.Value);

            CharacterDisplayer(CheckNFTOwner.ownerDic);
            CheckNFTOwner.validAddress = true;
            validMessageChange.text = "Valid Address";
        }
        else{
            CheckNFTOwner.validAddress = false;
            MakeGray();
            validMessageChange.text = "Please Enter a Valid Ethereum Address";
        }
    }

    void Awake(){
        for(int i = 0; i < 14; i++){
            GameObject button = ParentPanel.transform.GetChild(i).gameObject;
            Button buttonClick = button.GetComponent<Button>();
            buttonClick.transform.SetParent(ParentPanel.transform);
            if(i == 13){
                button.GetComponent<Button>().interactable = true;
            }
            else{
                button.GetComponent<Button>().interactable = false;
            }
        }
    }

    void MakeGray(){
        for(int i = 0; i < 13; i++){
            GameObject button = ParentPanel.transform.GetChild(i).gameObject;
            Button buttonClick = button.GetComponent<Button>();
            buttonClick.transform.SetParent(ParentPanel.transform);
            button.GetComponent<Button>().interactable = false;
        }                      
    }

    private void CharacterDisplayer(Dictionary<int, bool> nftDic){
        for(int i = 0; i < 13; i++){
            if (nftDic[i] == true){
                GameObject button = ParentPanel.transform.GetChild(i).gameObject;
                Button buttonClick = button.GetComponent<Button>();
                buttonClick.transform.SetParent(ParentPanel.transform);
                button.GetComponent<Button>().interactable = true;
            }
            else{
                GameObject button = ParentPanel.transform.GetChild(i).gameObject;
                Button buttonClick = button.GetComponent<Button>();
                buttonClick.transform.SetParent(ParentPanel.transform);
                button.GetComponent<Button>().interactable = false;
            }                      
        }
    }
}
