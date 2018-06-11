using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forgerecipiescript : MonoBehaviour {
    public ForgeRecipie ForgeRecipie;
    public Text Name;
    public Image Icon;
    public Text Type;
    public Text forgetime;
    public Text resourceQuantity;
    public Text effectDuration;
    public Text XpGained;
    public Text Description;
    
    // Use this for initialization
    void Start () {
        Name.text = ForgeRecipie.Name;
        Icon.sprite = ForgeRecipie.Icon;
        Type.text = ForgeRecipie.Type;
        forgetime.text = ForgeRecipie.forgetime[0].ToString();
        resourceQuantity.text = ForgeRecipie.resourceQuantity[0].ToString();
        XpGained.text = ForgeRecipie.XpGained[0].ToString();
        Description.text = ForgeRecipie.Description;
        for (int i = 1; i < ForgeRecipie.forgetime.Length; i++) {
            forgetime.text += ","+ ForgeRecipie.forgetime[i].ToString();
            resourceQuantity.text += "," + ForgeRecipie.resourceQuantity[i].ToString();
            XpGained.text += ","+ForgeRecipie.XpGained[0].ToString();
        }
        forgetime.text += "Hours";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
