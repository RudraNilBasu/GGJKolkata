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

    public bool startCountdown = false;

	// Use this for initialization
	void Start () {
        countdownText.text = ((int)timeLeft).ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (startCountdown)
        {
            timeLeft -= Time.deltaTime;
            countdownText.text = ((int)timeLeft).ToString();
            if (timeLeft < 0)
            {
                countdownText.text = "0";
                theBall.GetComponent<ControlTwo>().timeUp();
                //Time.timeScale = 0.2f;
                if (theBall.GetComponent<BoxCollider2D>() != null)
                {
                    Debug.Log("timeup1");
                    theBall.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }
}
