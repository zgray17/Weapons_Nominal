using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
//Author:Zak Gray
public class GUIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void twoPlayer()
    {
        //SceneManager.LoadScene("TwoPlayerScene");
    }
    public void threePlayer()
    {
        LoadingScreenManager.LoadScene(2);
    }
    public void quit()
    {
        Application.Quit();
    }
}
