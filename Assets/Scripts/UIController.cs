using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour {

    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] SettingsPopup settingsPopup;

    // Start is called before the first frame update
    void Start() {
        settingsPopup.Close();
    }

    // Update is called once per frame
    void Update() {
        scoreLabel.text = Time.realtimeSinceStartup.ToString();
    }

    public void OnOpenSettings() {
        // Debug.Log("Opening settings...");
        settingsPopup.Open();
    }
}
