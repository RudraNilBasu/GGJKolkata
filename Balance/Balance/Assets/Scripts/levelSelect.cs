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

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void exit()
    {
        Application.Quit();
    }
}
