using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour {


    public void OpenFight()
    {
        //SceneManager.LoadSceneAsync(0);
        SceneManager.LoadScene("ArFightScene");
    }
}
