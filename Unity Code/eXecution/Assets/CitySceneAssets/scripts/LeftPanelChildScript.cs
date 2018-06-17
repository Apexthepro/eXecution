using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftPanelChildScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void RegisterClick()
    {
        for (int i = 0; i < gameObject.GetComponentInParent<MailScript>().LeftPanelChild.Length; i++)
        {
            print("Entred " + transform.parent.name);
            if (gameObject.GetComponentInParent<MailScript>().LeftPanelChild[i].name == transform.parent.name)
            {
                gameObject.GetComponentInParent<MailScript>().ActiveLeftChildIndex = i;
            }

        }
        gameObject.GetComponentInParent<MailScript>().LoadNewMessages();
        gameObject.GetComponentInParent<MailScript>().InitializeLeftPanelChild();
    }
}
