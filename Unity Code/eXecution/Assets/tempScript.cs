using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class tempScript : MonoBehaviour, IPointerClickHandler
{
    public Animator slideAnimation;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        print("Entred");
        slideAnimation.SetBool("OpenMenu", false);
    }

}
