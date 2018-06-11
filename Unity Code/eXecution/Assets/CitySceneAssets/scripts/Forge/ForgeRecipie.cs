using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Forge Recipie", menuName = "Forge Recipies")]
public class ForgeRecipie : ScriptableObject
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