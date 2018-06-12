using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class slideScript : MonoBehaviour {
    public Hero Hero;
    public Text heroname, heath, healthregen, mana, manaregen, type, damage,armorstat;
    public Image spell1, spell2, spell3, spell4, helmet, armor, pant, boot, weapon1, weapon2;
    // Use this for initialization
    void Start () {
        

    }
    public void initiateSlide() {
        print("In slide" + transform.position);
        transform.localScale = new Vector3(0.92f, 0.92f, 0.92f);
        heroname.text = Hero.name;
        heath.text = Hero.Health.ToString();
        healthregen.text = Hero.HealthRegenpersecond.ToString();
        mana.text = Hero.BaseMana.ToString();
        manaregen.text = Hero.ManaRegenpersecond.ToString();
        type.text = Hero.Type;
        damage.text = Hero.BaseDamage.ToString();
        armorstat.text = Hero.BaseArmour.ToString();
        spell1.sprite = Hero.Spells[0].spellIcon;
        spell2.sprite = Hero.Spells[1].spellIcon;
        spell3.sprite = Hero.Spells[2].spellIcon;
        spell4.sprite = Hero.Spells[3].spellIcon;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
