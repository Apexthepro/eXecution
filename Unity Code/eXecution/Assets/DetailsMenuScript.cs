using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Newtonsoft.Json;
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
        somemenu.SetActive(true);
    }
    public void MenuOpened() {
        DataSnapshot details_snapshot;
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance.GetReference("BuildingsInfo").Child(BuildingGlocalScript.BuildingsArr[BuildingGlocalScript.CurrentBuildingIndex].name + "details").GetValueAsync().ContinueWith(task2 =>
        {
            details_snapshot = task2.Result;
            if (task2.IsCompleted)
            {
                var a = details_snapshot.Children;
                dbinitscript.jddata = JsonConvert.DeserializeObject<jsondetailsdata>(details_snapshot.GetRawJsonValue());
                BuildingDescription.text = dbinitscript.jddata.Details.ToString();
                CurrentlevelText.text = "Current Level " + dbinitscript.jddata.lev.ToString();
                TableBuildingName.text = BuildingGlocalScript.BuildingsArr[BuildingGlocalScript.CurrentBuildingIndex].name + " Details";
                BuildinglevText.text = BuildingGlocalScript.BuildingsArr[BuildingGlocalScript.CurrentBuildingIndex].name + " Lvl " + dbinitscript.jddata.lev.ToString();
                buff1desc.text = dbinitscript.jddata.buff1desc.ToString();
                buff2desc.text = dbinitscript.jddata.buff2desc.ToString();
                InfoText.text = BuildingDescription.text;
                //while (a.GetEnumerator().MoveNext())
                {
                    //print("Key->" + a.GetEnumerator().Current.Key + "Value->" + a.GetEnumerator().Current.Child("buff1").Value);
                }
                /*
                           //   science reserchspedd 5% +0.05%
                           while (a.GetEnumerator().MoveNext())
                           {
                               if (a.GetEnumerator().Current.Key == dbinitscript.data.Buildings.Forge.lev.ToString())
                               {
                                   a.GetEnumerator().MoveNext();
                                   BuildingBuffInformation.text =
                                   //dbinitscript.jddata.Forgedetails.buff1desc.ToString() +" "+ dbinitscript.data.Buffs.ResearchResources.ToString()+
                                   "+"+ a.GetEnumerator().Current.Child("buff1").Value.ToString();
                                   break;
                               }

                           }*/
          
                foreach (Transform child in rowParent.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                a.GetEnumerator().Reset();
                var en = a.GetEnumerator();
                while (en.MoveNext())//no of rows
                {
                    print("Keys-->"+a.GetEnumerator().Current.Key);
                    if (en.Current.Key.Equals("levels"))
                        a = en.Current.Children;
                    //CreateRow(a.GetEnumerator().Current.Key.ToString(), a.GetEnumerator().Current.Child("prestige").Value.ToString(), a.GetEnumerator().Current.Child("buff1").Value.ToString(), a.GetEnumerator().Current.Child("buff2").Value.ToString());//row content                    
                }
                while(a.GetEnumerator().MoveNext())
                {
                    CreateRow(a.GetEnumerator().Current.Key.ToString(), a.GetEnumerator().Current.Child("prestige").Value.ToString(), a.GetEnumerator().Current.Child("buff1").Value.ToString(), a.GetEnumerator().Current.Child("buff2").Value.ToString());//row content                    
                    //print(a.GetEnumerator().Current.Key.ToString() + "," + a.GetEnumerator().Current.Child("prestige").Value.ToString() + "," + a.GetEnumerator().Current.Child("buff1").Value.ToString() + "," + a.GetEnumerator().Current.Child("buff2").Value.ToString());//row content                    

                }
            }
        });

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
