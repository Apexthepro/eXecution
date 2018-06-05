using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingInput : MonoBehaviour
{
    float position;
    public Text console;
    public BuildingsGlobalScript BuildingsGlobalScript;
    public UiCanvasScript UiCanvasScript;
    void Start()
    {

    }
    void OnMouseUp()
    {
       // error("Input detected ");
        if (!EventSystem.current.IsPointerOverGameObject() && UiCanvasScript.activeMenus == null)
        {
            UiCanvasScript.DisplayBuildinNames(true);
            BuildingsGlobalScript.ShowMenu(name);
        }
    }
    public void UpgradeButton()
    {
        BuildingsGlobalScript.UpgradeMenu(name);
    }
    public void EnterButton()
    {
        BuildingsGlobalScript.EnterMenu(name);
    }
    public void InformationButton()
    {
        BuildingsGlobalScript.DetailsMenu(name);
    }

    private void error(string msg) {
        console.text =  console.text + "\n --> "+ msg;
    }


}




//useful code snippets
//howto chnage scene
//Application.LoadLevel(sceneName);
//Addscript to camera
//Addscene to build
// print("Object position is " + transform.position);
//transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
//                foreach (Transform child in transform)
//            transform.GetChild(1).gameObject.SetActive(true);
//        selectorArr = new GameObject[numSelectors];

