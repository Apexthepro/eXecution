using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{

    public string Name;
    public Sprite Icon;
    public string Type;
    public float[] forgetime;
    public float[] resourceQuantity;
    public float[] effectDuration;
    public int[] XpGained;
    public string Description;

}