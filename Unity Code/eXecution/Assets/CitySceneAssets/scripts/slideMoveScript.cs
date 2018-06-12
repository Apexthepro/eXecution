using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class slideMoveScript : MonoBehaviour {
    public Button previousHero;
    public Button nextHero;
    public GameObject panelprevious;
    public GameObject panelnext;
    public int currentSlide;
    public GameObject SlideParent;
    public GameObject SlidePrefab;
    public GameObject[] HeroIcons;
    public GameObject[] Slides;
    public GameObject[] Spell;
    public SpellInfoCardScript SpellInfoCardScript;
    public SettingsMenuScript SettingsMenuScript;
    public GameObject SpellInfo;
    public GameObject SpellInfoPrefab;
    public GameObject GridLayout;
    public bool spellSetFlag=false;
    // Use this for initialization
    void Start () {
        
    }
    public void setCurrentSlide(int currentHeroIconIndex) {
        currentSlide = currentHeroIconIndex;
        setUpSlides();
    }
    public void setUpSlides() {
        //Destroy old slides first


        //initiate slides based on hero icons
        //Sort slides in proper order
        //determine the slide clicked and display it
   //     print("Setting up slides...");
        for (int i = 0; i < Slides.Length; i++)
        {
            print("Destryoing" + Slides[i].name);
            Destroy(Slides[i]);
        }
        Slides = new GameObject[HeroIcons.Length];
        // print("slide[0].name "+Slides[0].name);
        if (currentSlide == 0)
        {
            panelprevious.gameObject.SetActive(false);
        }
        if (currentSlide > 0) {
            panelprevious.gameObject.SetActive(true);
        }
        if (currentSlide < HeroIcons.Length-1)
        {
            panelnext.gameObject.SetActive(true);
        }
        
        if (currentSlide == HeroIcons.Length-1)
        {
            panelnext.gameObject.SetActive(false);
        }
        for (int i=0;i<HeroIcons.Length;i++) {
            
         //   print("i  is " + i+ "currentSlide "+ currentSlide);
            if (i < currentSlide)
            {//set before
                Slides[i] = Instantiate(SlidePrefab);
              //  print("Position Before parent "+ Slides[i].transform.position);
                Slides[i].transform.SetParent( SlideParent.transform);
               // print("Position after parent " + Slides[i].transform.position);
                Slides[i].transform.position = new Vector3(-753, 400, 0);
                //print("after explicit stateting " + Slides[i].transform.position);
                Slides[i].GetComponent<slideScript>().Hero = HeroIcons[i].GetComponent<IconInfoScript>().hero;
                Slides[i].GetComponent<slideScript>().initiateSlide();
            }

            else if (i == currentSlide)//set in frame
            {
                Slides[i] = Instantiate(SlidePrefab);
                Slides[i].transform.SetParent(SlideParent.transform);
                Slides[i].transform.position = new Vector3(625, 400, 0);
                Slides[i].GetComponent<slideScript>().Hero = HeroIcons[i].GetComponent<IconInfoScript>().hero;
                Slides[i].GetComponent<slideScript>().initiateSlide();

            }
            else//set after frame
            {
                Slides[i] = Instantiate(SlidePrefab);
                Slides[i].transform.SetParent(SlideParent.transform);
                Slides[i].transform.position = new Vector3(2100, 400, 0);
                Slides[i].GetComponent<slideScript>().Hero = HeroIcons[i].GetComponent<IconInfoScript>().hero;
                Slides[i].GetComponent<slideScript>().initiateSlide();

            }
        }

        instantiateSlideButtons();
    }
    public void nextSlide() {
        
        panelprevious.gameObject.SetActive(true);

        if (currentSlide + 1 < HeroIcons.Length)
        {
         //   print("Going To next hero");
            Slides[currentSlide].transform.position = new Vector3(2100, 400, 0);
            currentSlide++;
            Slides[currentSlide].transform.position = new Vector3(625, 400, 0);
        }
        if (currentSlide == HeroIcons.Length - 1)
        {
            panelnext.gameObject.SetActive(false);
        }
    }
    public void previousSlide()
    {
    //    print("Going To previous hero");
        if (currentSlide - 1 >= 0)
        {
            Slides[currentSlide].transform.position = new Vector3(-753, 400, 0);
            currentSlide--;
            Slides[currentSlide].transform.position = new Vector3(625, 400, 0);
        }
        panelnext.gameObject.SetActive(true);
        if (currentSlide == 0)
        {
            panelprevious.gameObject.SetActive(false);
        }
    }
    public void instantiateSlideButtons() {
        print("Instantiating spellinfo");
        for (int i=0;i<Slides.Length;i++) {
            Slides[i].GetComponent<slideScript>().spell1.GetComponent<Button>().onClick.AddListener(() => SettingsMenuScript.MenuButtonClick(SpellInfo));
            Slides[i].GetComponent<slideScript>().spell2.GetComponent<Button>().onClick.AddListener(() => SettingsMenuScript.MenuButtonClick(SpellInfo));
            Slides[i].GetComponent<slideScript>().spell3.GetComponent<Button>().onClick.AddListener(() => SettingsMenuScript.MenuButtonClick(SpellInfo));
            Slides[i].GetComponent<slideScript>().spell4.GetComponent<Button>().onClick.AddListener(() => SettingsMenuScript.MenuButtonClick(SpellInfo));
            Slides[i].GetComponent<slideScript>().spell1.GetComponent<Button>().onClick.AddListener(() => openSpellInfo(1));
            Slides[i].GetComponent<slideScript>().spell2.GetComponent<Button>().onClick.AddListener(() => openSpellInfo(2));
            Slides[i].GetComponent<slideScript>().spell3.GetComponent<Button>().onClick.AddListener(() => openSpellInfo(3));
            Slides[i].GetComponent<slideScript>().spell4.GetComponent<Button>().onClick.AddListener(() => openSpellInfo(4));

        }

    }
    public void openSpellInfo(int spellclicked)
    {
        if (spellSetFlag == true)
        {
            for (int i = 0; i < Slides[currentSlide].GetComponent<slideScript>().Hero.Spells.Length; i++)
            {
                print("Destryoing Spells" + Spell[i].name);
                Destroy(Spell[i]);
                
            }
            spellSetFlag = false;
        }
        Spell = new GameObject[Slides[currentSlide].GetComponent<slideScript>().Hero.Spells.Length];

            for (int i=0;i< Slides[currentSlide].GetComponent<slideScript>().Hero.Spells.Length;i++) {

                Spell[i] = Instantiate(SpellInfoPrefab);
                Spell[i].transform.SetParent(GridLayout.transform);
                GridLayout.transform.position = new Vector3(GridLayout.transform.position.x, 180, GridLayout.transform.position.z);
                Spell[i].GetComponent<SpellInfoCardScript>().spell = Slides[currentSlide].GetComponent<slideScript>().Hero.Spells[i];
                Spell[i].GetComponent<SpellInfoCardScript>().InstantiateSpellInfo();
                spellSetFlag = true;
            }
        

        
        print("openning spells for "+ spellclicked);

    }
    // Update is called once per frame
    void Update () {
		
	}
}
