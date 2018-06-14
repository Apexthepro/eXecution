using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadingScreenScript : MonoBehaviour {
    public GameObject loadingScreenObject;
    public Image LoadingBar;
    string path = "Assets/sam.txt";
    /*// Use this for initialization
	void Start () {
    }
    public void LoadScreen() {
        
    }
    // Update is called once per frame
    IEnumerator LoadingScreen() {
        //SceneManager.LoadScene(0);
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            if(async.progress == 0.9)
            LoadingBar.fillAmount = 1f;
            async.allowSceneActivation = true;
        }
        yield return null;
    }
	void Update () {
        StartCoroutine(LoadingScreen());

    }*/
    void Start()
    {
        StartCoroutine(LoadYourAsyncScene());
    }
    void Update()
    {
        // Press the space key to start coroutine

            // Use a coroutine to load the Scene in the background
            

    }
    AsyncOperation asyncLoad;
    IEnumerator LoadYourAsyncScene()
    {
        using (StreamReader file = new StreamReader(path))
        {
            if (file.ReadLine() == null)
            {
                asyncLoad = SceneManager.LoadSceneAsync("LoginScene");
            }
            asyncLoad = SceneManager.LoadSceneAsync("CastleScene");
            file.Close();

        }
        // print("Before waiting");
        //asyncLoad = SceneManager.LoadSceneAsync("LoginScene");
        asyncLoad = SceneManager.LoadSceneAsync("CastleScene");
        asyncLoad.allowSceneActivation = false;
        //print("enter 1");
        // Wait until the asynchronous scene fully loads

       // yield return new WaitForSeconds(2.0f);
        while (asyncLoad.isDone == false)
        {
            //print("Still Loading.." + asyncLoad.progress);
            LoadingBar.fillAmount = asyncLoad.progress;
            if (asyncLoad.progress == 0.9f)
            {
            //    print("Entred 3");
                LoadingBar.fillAmount = 1f;
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
        print("Load Complete");
        
    }
}
