using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpellInfoCardScript : MonoBehaviour {

    // Use this for initialization
    public Spell spell;
    public Text spellName;
    public Image spellIcon;
    public Text spellDescription;
    public Text spellmanaCost;
    public Text spelldamage;
    public Text spellCooldown;
    public Text spellStunDuration;
    void Start () {
        
        
    }
    public void InstantiateSpellInfo() {
        print("ENtred"+spell.name);
              spellName.text = spell.name;
              spellDescription.text = spell.description;
              spellmanaCost.text = spell.manaCost.ToString();
              spelldamage.text = spell.damage.ToString();
              spellCooldown.text = spell.Cooldown.ToString();
              spellStunDuration.text = spell.StunDuration.ToString();
              spellIcon.sprite = spell.spellIcon;
          

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
