using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class InventoryScript : MonoBehaviour {
    public GameObject myItemsPanel;
    public GameObject shoppingPanel;
    public GameObject[] submenulist;
    public int itemCount;
    public GameObject CurrentItemClicked;
    // Use this for initialization
    

    public void OpenMyItems()
    {
        shoppingPanel.SetActive(false);
        myItemsPanel.SetActive(true);
    }
    public void UseItem()
    {
        print("Item Used");
        HideSubmenus();
        //transform.GetChild(0).transform.GetChild(0).transform.GetChild(0)
    }
    public void OpenItemUseMenu(GameObject itemClicked)
    {
        CurrentItemClicked = itemClicked;
        itemCount = Convert.ToInt32(itemClicked.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text);
        print("-->Item Count " + itemCount);
        if (itemCount > 1)
        {
            submenulist[1].SetActive(true);//Display multiple item use slide

        }
        //transform.GetChild(0).transform.GetChild(0).transform.GetChild(0)
    }
    public void OpenSubmenu(GameObject Menu) {
        Menu.SetActive(true);
    }
    public void OpenShop()
    {
        shoppingPanel.SetActive(true);
        myItemsPanel.SetActive(false);
    }
    public void HideSubmenus() {
        for (int i = 0; i < submenulist.Length; i++)
        {
            submenulist[i].SetActive(false);
        }
    }
}
