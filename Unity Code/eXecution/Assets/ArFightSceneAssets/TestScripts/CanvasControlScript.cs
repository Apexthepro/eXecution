using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CanvasControlScript : MonoBehaviour {
    public Button[] buttons;
    public Text[] text;
    public Image[] image;
    public GameObject[] panel;
    public int noofbuttonsoncooldown=0;
    public float CoolDown;
    public int ButtonId;
    public float[] coolDownList;
    public float[] timeleftlist;
    public Text KilltextDisplaytextbox;
    // Use this for initialization
    void Start () {
 
        coolDownList = new float[buttons.Length];
        timeleftlist = new float[buttons.Length];


        
    }
    private void Update()
    {

            for (int i = 0; i < coolDownList.Length; i++)
            {

                if (timeleftlist[i] > 0)
                {
                    buttons[i].interactable = false;
                    panel[i].SetActive(true);
                    //print("i : " + i + " timeLeftList " + timeleftlist[i]);
                    timeleftlist[i] -= Time.deltaTime;
                    image[i].fillAmount = timeleftlist[i] / coolDownList[i];
                    text[i].text = timeleftlist[i].ToString("F");

                }
                else
                {
                    //   print("button : " + i + " cooldowncomplete ");
                    buttons[i].interactable = true;
                    panel[i].SetActive(false);
                    coolDownList[i] = 0;
                    timeleftlist[i] = 0;
                }
                


            }
        
    }
    public void Back() {
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    public void CastSpell(int ButtonId) {

        
    }
    public void SpellButtonUI(int ButtonId,float SpellCoolDown) {
 
        coolDownList[ButtonId] = SpellCoolDown;
        timeleftlist[ButtonId] = SpellCoolDown;
        noofbuttonsoncooldown = 0;
        // .GetComponentInChildren<Text>()
    }
    public void printKillInfo(string monsterkillinfo) {
        KilltextDisplaytextbox.text = monsterkillinfo;
        StartCoroutine(Hide(KilltextDisplaytextbox, 4.0f));
       
       // KilltextDisplaytextbox.enabled = true;
    }
    IEnumerator Hide(Text Text,float time)
    {
        print("Entred");
        yield return new WaitForSeconds(time);
        Text.text = "";

        StopCoroutine(Hide(Text,time));
    }
    // print("Before waiting");

}
