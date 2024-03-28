using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour {

    // opens the popup for settings
    public void Open() {
        gameObject.SetActive(true);
    }

    // closes the popup for settings
    public void Close() {
        gameObject.SetActive(false);
    }

    public void OnSubmitName(string name) {
        Debug.Log(name);
    }

    public void OnSpeedValue(float speed) {
        Debug.Log($"Speed: {speed}");
    }
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
