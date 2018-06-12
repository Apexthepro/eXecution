using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconInfoScript : MonoBehaviour {
    public Hero hero;
    public Text heroname;
    public Image heroicon;

	// Use this for initialization
	void Start () {
        heroname.text = hero.name;
        heroicon.sprite = hero.HeroIcon;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
