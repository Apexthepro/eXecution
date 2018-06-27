using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class rightMeuScript : MonoBehaviour, IPointerClickHandler
{
    public Animator slideAnimation;
	// Use this for initialization
	void Start () {
        slideAnimation.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerClick(PointerEventData eventData)
    {
        print("Entred");
        slideAnimation.enabled = true;
        slideAnimation.SetBool("OpenMenu",true);
    }

}
