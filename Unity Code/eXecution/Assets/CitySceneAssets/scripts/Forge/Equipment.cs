using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Equipment")]
public class Equipment : ScriptableObject
{

    public string Name;
    public Sprite Icon;
    public string Type;//Combat/Development
    public string WeaponType;//meele/range
    public string GearType;//Helmet/armor/axe/ring/sword/pants
    public Spell[] spell;
    public float Damage;
    public float attackspeed;
    public float upgradespeed;
    public float researchspeed;
    public string Description;
    public Equipment[] UpgradeTo;
    public Equipment[] DisassembleTo;
}