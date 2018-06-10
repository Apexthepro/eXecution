using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidespellInfo : MonoBehaviour {

    // Use this for initialization

    public void hidespellinfo() { 
        gameObject.SetActive(false);
    }
    public void showspellInfo()
    {
        gameObject.SetActive(true);
    }
}
