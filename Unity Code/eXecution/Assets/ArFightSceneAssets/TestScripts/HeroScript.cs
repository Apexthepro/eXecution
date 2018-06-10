using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour {
    public Hero Hero;
    public CanvasControlScript CanvasControlScript;
    public float attackspeed ;
    // Use this for initialization
    void Start () {
        print("Hero Name is " + Hero.name);
        


        
    }
    public void CastSpell(int spellIndex)
    {
        if (Hero.Spells[spellIndex].type == "Passive") {
            return;
        }
        if (Hero.Spells[spellIndex].manaCost<= Hero.currentMana) {
            CanvasControlScript.SpellButtonUI(spellIndex, Hero.Spells[spellIndex].Cooldown);//IF spell casted trigger button cd
            Hero.Spells[spellIndex].ParticlePrefab.GetComponent<SpellScript>().spell = Hero.Spells[spellIndex];//assign spell to spell prefab spell
            Hero.Spells[spellIndex].ParticlePrefab.GetComponent<SpellScript>().hero = Hero;//assign hero to spell prefab hero
            Hero.Spells[spellIndex].ParticlePrefab.GetComponent<SpellScript>().playername = "apexthepro";//assign playername to spell prefab playername
            if (Hero.Spells[spellIndex].name == "LightningBlade")
            {
                //calculate all additional damage here
                Hero.Spells[spellIndex].damage = Hero.BaseDamage;
                var spell = (GameObject)Instantiate(Hero.Spells[spellIndex].ParticlePrefab, Hero.SpellSpawn.transform.position, Hero.SpellSpawn.transform.rotation);
                    // print("Hero.SpellSpawn.transform.position"+ Hero.SpellSpawn.transform.position);
                spell.GetComponent<Rigidbody>().velocity = spell.transform.forward * attackspeed;
                Destroy(spell, Hero.Spells[spellIndex].Duration);
                   // print("Casting Spell" + Hero.Spells[spellIndex].name);

            }
            

        }
        else {
            print("Not Enough Mana");
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

}
