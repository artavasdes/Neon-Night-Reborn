using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadStageSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadStageSelectScene() {
        Application.LoadLevel("Scenes/StageSelect");
    }
}
