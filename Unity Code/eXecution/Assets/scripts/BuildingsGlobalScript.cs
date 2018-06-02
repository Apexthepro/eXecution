using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour {
    string buildingName;
    float upgradeTime;
    int Level;

}


public class BuildingsGlobalScript : MonoBehaviour {

    // Use this for initialization
    public UiCanvasScript UiCanvasScript;
    public float MaxTime;
    private GameObject UpgradeUIPanel;
    private Text upgradetime;
    private Image LoadingBar;
    private bool LoadingBarEnable=false;
    private float time = 0;
    public Text console;
    public int count = 0;
   
    //private int builderCount = 3;
    //private int currentNoOfbuildingsUpgrading = 0;
    public GameObject[] BuildingsArr;
    public int CurrentBuildingIndex;

    void Start () {
        CurrentBuildingIndex = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (LoadingBarEnable) {
            if (time <= MaxTime)
            {
                time += Time.deltaTime;
                error("Time.deltaTime"+ Time.deltaTime +"Max time is "+MaxTime );
                LoadingBar.fillAmount = time / MaxTime;
                upgradetime.text = "Time : " + time.ToString("F");
            }
            else
            {
                LoadingBarEnable = false;
                UpgradeUIPanel.SetActive(false);
                time = 0;
            }
        }
        
    }
    public void ShowMenu(string bldg) {
        error("Curent Building " + bldg);
        if (BuildingsArr[CurrentBuildingIndex].name != bldg)//Check if same building clicked
        {
            for (int i = 1; i < BuildingsArr.Length; i++)
            {
                if (BuildingsArr[i].name == bldg)
                {
                    CurrentBuildingIndex = i;
                }
            }
            if (CurrentBuildingIndex != 0)//check if any other menu open
            {
                //BuildingsArr[CurrentBuildingIndex].transform.GetChild(1).gameObject.SetActive(false);//hide open menus
                BuildingsArr[0].transform.position = BuildingsArr[CurrentBuildingIndex].transform.position + new Vector3(0f,-1.4f,0f);

            }
            BuildingsArr[0].SetActive(true);
        }
        else {
            BuildingsArr[0].SetActive(false);//If same building clicked hide menu for the building
            CurrentBuildingIndex = 0;//reset previous variable
        }
    }
    public void DetailsMenu(string bldg)//Details menu Button
    {
        error("Opening Details Menu for " + bldg);

    }
    public void UpgradeMenu(string bldg)
    {

        BuildingsArr[0].SetActive(false);

        error("Opening Upgrade Menu for " + bldg);
        //GameObject.Find(previousBuilding).transform.GetChild(1).gameObject.SetActive(false);



    }
    public void UpgradeBuilding() {
        UpgradeUIPanel = BuildingsArr[CurrentBuildingIndex].transform.GetChild(0).transform.GetChild(2).gameObject;
        UpgradeUIPanel.SetActive(true);
        upgradetime = UpgradeUIPanel.transform.GetChild(0).GetComponent<Text>();
        LoadingBar = UpgradeUIPanel.transform.GetChild(1).GetComponent<Image>();
        LoadingBarEnable = true;
        UiCanvasScript.Close();
    }
    public void EnterMenu(string bldg)
    {
        error("Entering " + bldg);

    }

    private void error(string msg)//console error print function
    {
        console.text = "\n --> " + msg;
    }
}
