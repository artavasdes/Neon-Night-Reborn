using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public class loadInputs1 : MonoBehaviour
{
    public InputDevice playerOneInput;
    public InputDevice playerTwoInput;

    ReadOnlyArray<InputDevice> devices;
    Input[] inputs;
    int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        devices = InputSystem.devices;
        Debug.Log(devices.Count);
        inputs = new Input[devices.Count];
        int i = 0;
        
        
        foreach (var device in devices)
        {
            inputs[i] = (new Input(device));
            Debug.Log(device.displayName);
            i++;
        }


        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = inputs[index].icon;
        gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = inputs[index].name;
    }

    // Update is called once per frame

    bool check = true;

    [System.Obsolete]
    void Update()
    {
        // Debug.Log(check);
        // Debug.Log(gameObject.transform.parent.Find("inputDisplay").GetChild(5).gameObject.active);
        if (check && gameObject.transform.parent.Find("inputDisplay").GetChild(5).gameObject.active) {

            foreach (var inp in inputs) {
                
                if (inp.inDevice.Equals(playerOneInput)) {
                    Debug.Log("RUNS");
                    inp.enabled = false;
                    check = false;
                    break;
                }
            }
        }

        if (check && gameObject.transform.parent.Find("inputDisplay2").GetChild(5).gameObject.active) {

            foreach (var inp in inputs) {
                if (inp.inDevice.Equals(playerTwoInput)) {
                    inp.enabled = false;
                    check = false;
                    break;
                }
            }
        }
    }

    public void nextInput() {
        if (index == devices.Count - 1) {
            index = 0;
        }
        else {
            index++;
        }

        if (!(inputs[index].enabled)) {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Button>().interactable = false;
        }
        else {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Button>().interactable = true;
        }
        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = inputs[index].icon;
        gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = inputs[index].name;
    }


    public void prevInput() {
        if (index == 0) {
            index = devices.Count - 1;
        }
        else {
            index--;
        }

        if (!(inputs[index].enabled)) {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Button>().interactable = false;
        }
        else {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Button>().interactable = true;
        }
        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = inputs[index].icon;
        gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = inputs[index].name;
    }

    public void selectInput1() {
        playerOneInput = inputs[index].inDevice;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        gameObject.transform.GetChild(4).gameObject.SetActive(false);
        gameObject.transform.GetChild(5).gameObject.SetActive(true);
        Debug.Log(playerOneInput.displayName);
    }

    public void selectInput2() {
        playerTwoInput = inputs[index].inDevice;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        gameObject.transform.GetChild(4).gameObject.SetActive(false);
        gameObject.transform.GetChild(5).gameObject.SetActive(true);
        Debug.Log(playerTwoInput.displayName);
    }

    class Input {

        public string name;
        public string type;

        public Sprite icon;
        public InputDevice inDevice;
        public bool enabled;

        
        public Input(InputDevice inDevice) {
            name = inDevice.displayName;
            enabled = true;

            this.inDevice = inDevice;

            if (inDevice.displayName.Equals("Xbox Controller")) {
                icon = Resources.Load<Sprite>("InputIcons/xboxIcon");
            } else if (inDevice.displayName.Equals("Wireless Controller")) {
                icon = Resources.Load<Sprite>("InputIcons/ps4Icon");
            } else if (inDevice.displayName.Equals("Keyboard")) {
                icon = Resources.Load<Sprite>("InputIcons/kbmIcon");
            }
            else {
                icon = Resources.Load<Sprite>("inputIcons/generalIcon");
            }
            
        }

        
    }

    
}
