using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void menu()
    {
        SceneManager.LoadScene("menu");
    }

    public void exit()
    {
        Application.Quit();
    }
}
