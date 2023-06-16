using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void onHostButtonClick() {
      GlobalNetState.isHosting = true;

      SceneManager.LoadScene("StageSelect");
    }

    public void onConnectButtonClick() {
      GlobalNetState.isHosting = false;
      SceneManager.LoadScene("Fight Scene");
    }

    public void onCodeInputChange() {
      // SceneManager.LoadScene("BattleScene");
    }
}
