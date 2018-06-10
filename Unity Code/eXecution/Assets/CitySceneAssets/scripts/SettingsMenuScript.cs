using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour {
    public UiCanvasScript UiCanvasScript;
    public GameObject panel1;
    public string webClientId = "100493588325-4i2jj4nbem22p2r87mo1afn0uhar670o.apps.googleusercontent.com";
    // public GameObject panel2;
    // Use this for initialization
    void Start () {
        UiCanvasScript.activePanels[0] = panel1.gameObject;
        //activePanels[0] = panel1.gameObject;
        UiCanvasScript.currentPanel = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void MenuButtonClick(GameObject panel) {
        UiCanvasScript.activePanels[UiCanvasScript.currentPanel].SetActive(false);
        UiCanvasScript.currentPanel++;
        UiCanvasScript.activePanels[UiCanvasScript.currentPanel] = panel.gameObject;
        UiCanvasScript.activePanels[UiCanvasScript.currentPanel].SetActive(true);
        UiCanvasScript.backbutton.gameObject.SetActive(true);
    }
    //private GoogleSignInConfiguration configuration;
    public void Googlesigninclick() {
  
        print("Access api here");
    }

}
