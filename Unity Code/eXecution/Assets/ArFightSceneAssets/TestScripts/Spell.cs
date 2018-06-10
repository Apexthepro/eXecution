using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class Spell : ScriptableObject
{

    public new string name;
    public string description;
    public GameObject ParticlePrefab;
    public Collider ParticleCollider;
    public GameObject CollisionEffect;
    public Sprite spellIcon;
    public string type;
    public int manaCost;
    public float damage;
    public float Cooldown;
    public int ProjectileSpeed;
    public string damageType;
    public float Duration;

    public void Print()
    {
        Debug.Log(name + ": " + description );
    }



}