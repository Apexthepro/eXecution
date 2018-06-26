using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsMenuScript : MonoBehaviour {
    public Text BuildingDescription;
    public Text BuildingBuffInformation;
    public Text InfoText,BuildinglevText,TableBuildingName,buff1desc,buff2desc;
    public Text CurrentlevelText;
    public GameObject rowPrefab;
    private GameObject row;
    public GameObject rowParent;
    public GameObject MoreInfomationPanel;
    public BuildingsGlobalScript BuildingGlocalScript;
    public dbinitscript dbinitscript;
    public int nooflevels=35;
    // Use this for initialization
    void Start () {
       
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OpenMenu(GameObject somemenu)
    {
        print("Click Detected");
        somemenu.SetActive(true);
    }
    public void MenuOpened() {
        
        for (int i = 0; i < BuildingGlocalScript.BuildingsArr.Length; i++)
        {
            if (BuildingGlocalScript.BuildingsArr[i].name == "Forge") {
                print("forge details opened");
                BuildingDescription.text = dbinitscript.jddata.Forgedetails.Details.ToString();
                CurrentlevelText.text="Current Level " +dbinitscript.jddata.Forgedetails.lev.ToString();
                TableBuildingName.text = BuildingGlocalScript.BuildingsArr[i].name + " Details";
                BuildinglevText.text = BuildingGlocalScript.BuildingsArr[i].name + " Lvl "+ dbinitscript.jddata.Forgedetails.lev.ToString();
                buff1desc.text = dbinitscript.jddata.Forgedetails.buff1desc.ToString();
                buff2desc.text = dbinitscript.jddata.Forgedetails.buff2desc.ToString();
          //   science reserchspedd 5% +0.05%
                foreach (Transform child in rowParent.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                for (int j = 0; j < nooflevels; j++)//no of rows
                {
                    CreateRow(dbinitscript.jddata.Forgedetails.lev, dbinitscript.jddata.Forgedetails.Prestige, dbinitscript.jddata.Forgedetails.buff1, dbinitscript.jddata.Forgedetails.buff2);//row content
                }
                
            }
        }
    }
    public void close() {
        MoreInfomationPanel.SetActive(false);
    }
    public void CreateRow(string level,string prestige,string buff1,string buff2) {
        InfoText.text = BuildingDescription.text;
        row = Instantiate(rowPrefab, rowParent.transform.position, Quaternion.identity);
        row.transform.SetParent(rowParent.transform);
        row.transform.GetChild(0).GetComponent<Text>().text = level;
        row.transform.GetChild(1).GetComponent<Text>().text = prestige;
        row.transform.GetChild(2).GetComponent<Text>().text = buff1;
        row.transform.GetChild(3).GetComponent<Text>().text = buff2;
    }
}
