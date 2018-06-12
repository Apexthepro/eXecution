using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Hero", menuName = "Hero")]
public class Hero : ScriptableObject
{

    public new string name;
    public string description;
    public GameObject ModelPrefab;
    public Collider Collider;
    public Sprite HeroIcon;
    public string Type;
    public int Health;
    public int HealthRegenpersecond;
    public int BaseArmour;
    public int BaseMana;
    public int currentMana;
    public int ManaRegenpersecond;
    public int BaseDamage;
    public Spell[] Spells;
    public GameObject SpellSpawn;

    public void Print()
    {
        Debug.Log(name + ": " + description );
    }

}