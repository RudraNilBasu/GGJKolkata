using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class countdown : MonoBehaviour {

    [SerializeField]
    public float timeLeft;
    [SerializeField]
    Text countdownText;

    [SerializeField]
    GameObject theBall;

	// Use this for initialization
	void Start () {
        countdownText.text = ((int)timeLeft).ToString();
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        countdownText.text = ((int)timeLeft).ToString();
        if(timeLeft<0)
        {
            countdownText.text = "0";
            Time.timeScale = 0.2f;
            if (theBall.GetComponent<BoxCollider2D>() != null)
            {
                theBall.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
