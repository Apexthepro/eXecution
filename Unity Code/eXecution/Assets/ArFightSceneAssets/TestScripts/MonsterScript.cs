using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MonsterScript : MonoBehaviour {
    public Monster Monster;
    public float Health;
    public void Start()
    {
        Health = Monster.Health;
        //Monsternumber++;
        // spawnMonster(Monsternumber);
    }
    
    // Use this for initialization
    public bool TakeDamage(float amount, Spell Spell, Hero Hero,string playername) {
        //print("Monster hp is" + Health);
        Health -= amount;
        //print("Health Left "+ Health);
        if (Health <= 0f)
        {
            Die();
            GameObject.Find("ControlsCanvas").GetComponent<CanvasControlScript>().printKillInfo(Monster.name+" (lvl."+Monster.monsterLevel+") was killed by spell  " + Spell.name + " Used by hero " + Hero.name + " Who is controlled by player " + playername);
            print(Monster.name +" was killed by spell  " + Spell.name +" Used by hero "+Hero.name+" Who is controlled by player "+playername);
            return true;
        }
        return false;
    }
    void Die() {
        Destroy(gameObject);
    }

    
    // Update is called once per frame
    void Update () {
		
	}
}
