using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiCanvasScript : MonoBehaviour {
    public Text console;
    public GameObject activeMenus;
    public static GameObject[] activePanels;
    public static int currentPanel;
    public GameObject backbutton;
    public Pinch2Zoom Pinch2Zoom;
    public Camera MainCamera;
    private Vector3 PreviousCameraPosition;
    private float PreviousOrthographicSize;
    public BuildingsGlobalScript BuildingsGlobalScript;
    public GameObject TestBuilding;
    // Use this for initialization
    void Start () {
        activePanels = new GameObject[25];
    }
	
	// Update is called once per frame
	void Update () {
    }
    public void WorldMapClick() {
        error("Opening World Map");
    }
    public void OpenMenu(GameObject Menu) {
        error("Opening "+Menu);

        activeMenus = Menu.gameObject;
        activeMenus.SetActive(true);

        if (Menu.name == "SettingsMenu")
        {
            if (activePanels[currentPanel] != null)
                activePanels[currentPanel].SetActive(true);
        }
        backbutton.gameObject.SetActive(false);

        //UpgardeMenuStartScript
        if (Menu.name == "UpgradeMenu")
        {
            print("BuildingsGlobalScript.currentBuilding.transform.position" + TestBuilding.transform.position);
            PreviousCameraPosition = MainCamera.transform.position;
            MainCamera.transform.position = TestBuilding.transform.position + new Vector3(2f,0,0);
            PreviousOrthographicSize = MainCamera.orthographicSize;
            MainCamera.orthographicSize = 3.1f;
        }
    }
    
    public void LoginClick()
    {
        //add to activemenu aray
        error("Opening Settings");
        GameObject.Find("LoginMenuContainer").gameObject.SetActive(true);

    }
    public void Close() {
        error("Closing all menus");
        if (currentPanel > 0)
        {
            activePanels[currentPanel].SetActive(false);
            currentPanel = 0;
        }
        if (activeMenus.name == "UpgradeMenu")
        {
            MainCamera.transform.position = PreviousCameraPosition;
            MainCamera.orthographicSize = PreviousOrthographicSize;
        }
       // print("activeMenus.name " + activeMenus.name);
        activeMenus.SetActive(false);
        activeMenus = null;
        BuildingsGlobalScript.CurrentBuildingIndex = 0;
    }
    public void Back()
    {
        activePanels[currentPanel].SetActive(false);
        if (currentPanel - 1 >= 0)
            currentPanel -= 1;
        if (currentPanel == 0)
            backbutton.gameObject.SetActive(false);
        activePanels[currentPanel].SetActive(true);
        error("Currrent Panel"+currentPanel);

    }
    private void error(string msg)//console error print function
    {
        console.text = "\n --> " + msg;
    }
}
