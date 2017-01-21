using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class speed_mult : MonoBehaviour {

    [SerializeField]
    GameObject theBall;

    [SerializeField]
    Text pickupText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Player")
        {
            theBall.GetComponent<ControlTwo>().horizontalSpeed = 6f;
            pickupText.text = "Speed x 3";
            pickupText.GetComponent<Animation>().Play("pickupAnim");
            Destroy(gameObject);
        }
    }
}
