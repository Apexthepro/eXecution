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

    // Use this for initialization
    void Start () {
        
    }
    public void setCurrentSlide(int currentHeroIconIndex) {
        currentSlide = currentHeroIconIndex;
        setUpSlides();
    }
    public void setUpSlides() {
        //initiate slides based on hero icons
        //Sort slides in proper order
        //determine the slide clicked and display it
        Slides = new GameObject[HeroIcons.Length];
        // print("slide[0].name "+Slides[0].name);
        if (currentSlide > 0) {
            panelprevious.gameObject.SetActive(true);
        }
        if (currentSlide < HeroIcons.Length-1)
        {
            panelnext.gameObject.SetActive(true);
        }
        if (currentSlide == 0)
        {
            panelprevious.gameObject.SetActive(false);
        }
        if (currentSlide == HeroIcons.Length-1)
        {
            panelnext.gameObject.SetActive(false);
        }
        for (int i=0;i<HeroIcons.Length;i++) {
            print("i  is " + i+ "currentSlide "+ currentSlide);
            if (i < currentSlide)
            {//set before
                Slides[i] = Instantiate(SlidePrefab);
                print("Position Before parent "+ Slides[i].transform.position);
                Slides[i].transform.SetParent( SlideParent.transform);
                print("Position after parent " + Slides[i].transform.position);
                Slides[i].transform.position = new Vector3(-753, 400, 0);
                print("after explicit stateting " + Slides[i].transform.position);
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
        

    }
    public void nextSlide() {
        if (currentSlide == HeroIcons.Length-1)
        {
            panelnext.gameObject.SetActive(false);
        }
        panelprevious.gameObject.SetActive(true);

        if (currentSlide + 1 < HeroIcons.Length)
        {
            print("Going To next hero");
            Slides[currentSlide].transform.position = new Vector3(2100, 400, 0);
            currentSlide++;
            Slides[currentSlide].transform.position = new Vector3(625, 400, 0);
        }
    }
    public void previousSlide()
    {
        print("Going To previous hero");
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
    // Update is called once per frame
    void Update () {
		
	}
}
