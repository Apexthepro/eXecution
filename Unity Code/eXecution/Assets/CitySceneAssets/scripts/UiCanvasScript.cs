﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public bool DisplayBuildingNames;
    // Use this for initialization
    void Start () {
        activePanels = new GameObject[25];
        AudioListener.pause = !AudioListener.pause;
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void OpenMenu(GameObject Menu) {
       // print("Opening "+Menu);
        activeMenus = Menu.gameObject;
        activeMenus.SetActive(true);
        BuildingsGlobalScript.BuildingsArr[0].SetActive(false);
        backbutton.gameObject.SetActive(false);

        //UpgardeMenuStartScript
        if (Menu.name == "UpgradeMenu" || Menu.name == "DetailsMenu")
        {
            // print("BuildingsGlobalScript.currentBuilding.transform.position" + TestBuilding.transform.position);
            PreviousCameraPosition = MainCamera.transform.position;
            MainCamera.transform.position = BuildingsGlobalScript.BuildingsArr[BuildingsGlobalScript.CurrentBuildingIndex].transform.position + new Vector3(2.0f, -0.7f, -1f);
            PreviousOrthographicSize = MainCamera.orthographicSize;
            MainCamera.orthographicSize = 3.1f;
        }
        else {
            if (activePanels[currentPanel] != null)
                activePanels[currentPanel].SetActive(true);
        }
    }
    
    public void LoginClick()
    {
        //add to activemenu aray
       // error("Opening Settings");
        GameObject.Find("LoginMenuContainer").gameObject.SetActive(true);

    }
    public void Close() {
   //     print("Closing all menus");
        if (currentPanel > 0)
        {
            activePanels[currentPanel].SetActive(false);
            currentPanel = 0;
        }
        if (activeMenus.name == "UpgradeMenu" || activeMenus.name == "DetailsMenu")
        {
            MainCamera.transform.position = PreviousCameraPosition;
            MainCamera.orthographicSize = PreviousOrthographicSize;
        }
     //  print("activeMenus.name " + activeMenus.name);
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
    //    error("Currrent Panel"+currentPanel);

    }
    private void error(string msg)//console error print function
    {
        console.text = "\n --> " + msg;
    }
    public void Toggle_BuildingNames(bool currentSetting) {
        //      print("entred" + currentSetting);
        DisplayBuildingNames = currentSetting;
        for (int i = 1; i < BuildingsGlobalScript.BuildingsArr.Length; i++)
        {
            BuildingsGlobalScript.BuildingsArr[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(currentSetting);
//            print(BuildingsGlobalScript.BuildingsArr[i].transform.GetChild(0).transform.GetChild(0).name);
        }
    }
    public void Toggle_BackGroundMusic()
    {
        //      print("entred" + currentSetting);]
        AudioListener.pause = !AudioListener.pause;
        
    }
    public void DisplayBuildinNames(bool setvalue) {
        if (DisplayBuildingNames == false)
        {
            for (int i = 1; i < BuildingsGlobalScript.BuildingsArr.Length; i++)
            {
                BuildingsGlobalScript.BuildingsArr[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(setvalue);
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void OpenAr() {
        //SceneManager.LoadSceneAsync(0);
        SceneManager.LoadScene("ArMap");
    }
}
