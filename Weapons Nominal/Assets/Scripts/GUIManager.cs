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
        //SceneManager.LoadScene("TwoPlayerScene");
    }
    public void threePlayer()
    {
        SceneManager.LoadScene("ThreePlayerScene");
    }
    public void quit()
    {
        Application.Quit();
    }
}
