using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenuScript : MonoBehaviour {
    public UiCanvasScript UiCanvasScript;
    public GameObject panel1;
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
        UiCanvasScript.activePanels[0] = panel1.gameObject;
       // print("->panel1.gameObject " + panel1.gameObject.name);
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
