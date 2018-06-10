using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monster")]
public class Monster : ScriptableObject
{

    public new string name;
    public int monsterLevel;
    public string description;
    public GameObject ModelPrefab;
    public Collider Collider;
    public Sprite MonsterIcon;
    public int Health;
    public int HealthRegenpersecond;
    public int BaseArmour;
    public int BaseMana;
    public int currentMana;
    public int ManaRegenpersecond;
    public int BaseDamage;
    public Spell[] Spells;
    public GameObject SpellSpawn;



}