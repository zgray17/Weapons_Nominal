using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

public class GUIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void twoPlayer()
    {
        SceneManager.LoadScene(1);
    }
    public void threePlayer()
    {
        SceneManager.LoadScene(2);
    }
    public void quit()
    {
        Application.Quit();
    }
}
