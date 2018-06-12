using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class slideMoveScript : MonoBehaviour {
    public Button previousHero;
    public Button nextHero;
    public int currentSlide;
    public GameObject[] Slides;
    
    // Use this for initialization
    void Start () {
        currentSlide = 1;
        
        for (int i=0;i<Slides.Length;i++) {
            print("i "+i+" current slide "+currentSlide);
            if (i < currentSlide ) {//set before
                print("Setting "+i+" Before");
                print("Slides[i].transform.position " + Slides[i].transform.position);
                Slides[i].transform.position = new Vector3(-753, Slides[i].transform.position.y, 0);
                print("Slides[i].transform.position " + Slides[i].transform.position);
            }

            else if (i == currentSlide)//set in frame
            {
                Slides[i].transform.position = new Vector3(625, Slides[i].transform.position.y, 0); ;
                print("Setting " + i + " in frame");

            }
            else//set after frame
            {
                Slides[i].transform.position = new Vector3(2100, Slides[i].transform.position.y, 0);
                print("Setting " + i + " After");

            }
        }
    }
    public void nextSlide() {
        if (currentSlide + 1 < Slides.Length)
        {
            print("Going To next hero");
            Slides[currentSlide].transform.position = new Vector3(2100f, Slides[currentSlide].transform.position.y, 0f);
            currentSlide++;
            Slides[currentSlide].transform.position = new Vector3(625f, Slides[currentSlide].transform.position.y, 0f);
        }
    }
    public void previousSlide()
    {
        print("Going To previous hero");
        if (currentSlide - 1 >= 0)
        {
            Slides[currentSlide].transform.position = new Vector3(-753f, Slides[currentSlide].transform.position.y, 0f);
            currentSlide--;
            Slides[currentSlide].transform.position = new Vector3(625f, Slides[currentSlide].transform.position.y, 0f);
        }
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
