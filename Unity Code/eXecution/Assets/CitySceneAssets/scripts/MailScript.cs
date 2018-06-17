using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailScript : MonoBehaviour
{
    public GameObject[] LeftPanelChild;
    public GameObject[] RightPanelChild;
    public GameObject MessagePrefabParent;
    public GameObject[] notificationIcon;
    public GameObject MainMailButtonNotificationIcon;
    public GameObject PlayerMessagePrefab;
    public GameObject SystemMessagePrefab;
    private int notificationTemp = 1;
    public int ActiveLeftChildIndex = 0;
    public int ActiveRightChildIndex = -1;
    public Color ActiveColor, NormalColor;
    public GameObject PlayerChatPanel;
    public GameObject MailMessagePanel;
    public GameObject TempMessage;

    // Use this for initialization
    void Start()
    {

        InitializeLeftPanelChild();//initializing LeftPanelChilds
        LoadNewMessages();//initializing RightPanelChilds

    }
    public void LeftChildClicked()
    {


    }
    // Update is called once per frame
    void Update()
    {

    }
    public void InitializeLeftPanelChild()
    {
        print("Current Active Child : " + LeftPanelChild[ActiveLeftChildIndex].name);
        for (int i = 0; i < LeftPanelChild.Length; i++)
        {
            if (i == notificationTemp) //initialize NotificationIcon on the LeftPanelChilds
            {
                notificationIcon[i].SetActive(true);
            }
            else
            {
                notificationIcon[i].SetActive(false);
            }
            if (i == ActiveLeftChildIndex)//Setting Background color if active
            {
                LeftPanelChild[i].GetComponent<Image>().color = ActiveColor;
            }
            else
            {
                LeftPanelChild[i].GetComponent<Image>().color = NormalColor;
            }
        }
    }

    public void RemoveCurrentRightChild() {
        for (int i = 0; i < RightPanelChild.Length; i++)
            Destroy(RightPanelChild[i]);//Destroying Previous messages from array
    }
    public void LoadPrefab(GameObject prefab,int count) {
        RightPanelChild = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            TempMessage = Instantiate(prefab);
            TempMessage.transform.parent = MessagePrefabParent.transform;
            TempMessage.transform.localScale = new Vector3(1, 1, 1);
            TempMessage.name = i.ToString();
            
            TempMessage.GetComponentInChildren<MessagePrefabScript>().InitializePrefab();
            

            RightPanelChild[i] = TempMessage;
        }
    }
    public void LoadNewMessages() {
        RemoveCurrentRightChild();
        //Use code Below to add new child to right panel
        if (ActiveLeftChildIndex == 0)        //Check Which Left Panel Child is active
        {

            
            LoadPrefab(PlayerMessagePrefab, 10);
        }
        else
        {
            LoadPrefab(SystemMessagePrefab,5);
                
           
        }
    }
    public void RightChildClickRegistered()
    {
        print("ActiveRightChildIndex is "+ ActiveRightChildIndex);//Get the right child index who is clicked
        if (ActiveLeftChildIndex == 0)//Open chat
        {
            gameObject.GetComponent<SettingsMenuScript>().MenuButtonClick(PlayerChatPanel);//OpenChat
        }
        else//open Mail Message
        {
            gameObject.GetComponent<SettingsMenuScript>().MenuButtonClick(MailMessagePanel);//Open mail
        }
    }
}

