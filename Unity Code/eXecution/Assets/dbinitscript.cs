using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dbinitscript : MonoBehaviour {
    public Text resource1;
	// Use this for initialization
	void Start () {
        print("text is from"+resource1.text);
        resource1.text = "123m";

    }

	// Update is called once per frame
	void Update () {
		
	}
}
