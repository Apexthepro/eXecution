using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour {
    public string Belongstospell;
    public Spell spell;
    public GameObject CollidedObject = null;
    public Hero hero;
    public string playername;

    // Use this for initialization
    void Start () {
        Belongstospell = null;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision col)
    {
        CollidedObject = col.gameObject;
        
        //print("Spell Name is"+spell.name);

        if (spell.name == "LightningBlade") {
            Destroy(gameObject);//destroyspell on collision
            //do spell collision stuff here on spell end
            //perform spell special effects on collision here
            col.gameObject.GetComponent<MonsterScript>().TakeDamage(spell.damage*3,spell,hero,playername); //deal damage to monster
            //Update monster healthbar here
        }
     
    }

}
