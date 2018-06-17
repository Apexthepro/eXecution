using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsMenuScript : MonoBehaviour {
    public Text BuildingDescription;
    public Text BuildingBuffInformation;
    public GameObject MoreInfomationPanel;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OpenMenu(GameObject somemenu)
    {
        somemenu.SetActive(true);
    }
    public void close() {
        MoreInfomationPanel.SetActive(false);
    }
}
