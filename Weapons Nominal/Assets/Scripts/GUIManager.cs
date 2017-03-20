using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
//Author:Zak Gray
public class GUIManager : MonoBehaviour {
    public GameObject Canvas;
    public float speed;

    private bool menu;
	// Use this for initialization
	void Start () {
        menu = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape") || Input.GetButton("BButton"))
        {
            if(!menu)
            {
                Debug.Log("Esc");
                hideTutorial();
            }
        }
    if(!menu)
        {
            Canvas.GetComponent<RectTransform>().localPosition = Vector3.MoveTowards(Canvas.transform.position, new Vector3(822.6425F, -5050F, -221F), speed);
        }
    else
        {
            Canvas.GetComponent<RectTransform>().localPosition = Vector3.MoveTowards(Canvas.transform.position, new Vector3(822.6425F, 71.84321F, -221F), speed);
        }
	}

    public void twoPlayer()
    {
        LoadingScreenManager.LoadScene(3);
    }
    public void threePlayer()
    {
        LoadingScreenManager.LoadScene(4);
    }
    public void twoPlayerKeyboard()
    {
        LoadingScreenManager.LoadScene(2);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void showTutorial()
    {
        menu = false;
    }
    public void hideTutorial()
    {
        menu = true;
    }
}
