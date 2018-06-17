using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePrefabScript : MonoBehaviour {

    public Text MessageTitle;
    public Text MessageSubject;
    public Text Date;
    public Image MessageIcon;
    
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void InitializePrefab()
    {
        print("Initialzing Prefab");
    }
    public void RegisterClick()
    {
        for (int i = 0; i < gameObject.GetComponentInParent<MailScript>().RightPanelChild.Length; i++)
        {
            if (gameObject.GetComponentInParent<MailScript>().RightPanelChild[i].name == name)
            {
                gameObject.GetComponentInParent<MailScript>().ActiveRightChildIndex = i;
            }

        }
        gameObject.GetComponentInParent<MailScript>().RightChildClickRegistered();
    }
}
