using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class mouseDetect : MonoBehaviour
     , IPointerClickHandler // 2
     , IDragHandler
     , IPointerEnterHandler
     , IPointerExitHandler
// ... And many more available!
{

    public GameObject temp;
    void Awake()
    {
    }

    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {

    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        temp = this.transform.GetChild(2).gameObject;
        temp.SetActive(true);
        //  print("6th char" + this.name[6]);
        //print("Opening for spell "+this.transform.parent.GetComponentInChildren<slideScript>().spell[(int)char.GetNumericValue(this.name[6]) - 1].name);
        this.transform.GetChild(2).GetComponent<SpellInfoCardScript>().spell = this.transform.parent.GetComponentInChildren<slideScript>().spell[(int)char.GetNumericValue(this.name[6])-1];
        print("Opening for spell " + this.transform.GetChild(2).GetComponent<SpellInfoCardScript>().spell.name);
        this.transform.GetChild(2).GetComponent<SpellInfoCardScript>().InstantiateSpellInfo();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        temp.SetActive(false);
        //  this.transform.parent.transform.parent.GetComponent<slideScript>().initiateSlide();
        print("exit");
        this.transform.parent.GetComponentInParent<slideMoveScript>().closeSpellInfo();
    }
}

