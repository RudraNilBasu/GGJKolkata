using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Started");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="glass")
        {
            //Destroy(coll.gameObject);
            if( coll.gameObject.transform.parent)
            {
                Destroy(coll.gameObject.transform.parent.gameObject);
            }
            else {
                Destroy(coll.gameObject);
            }
        }
    }
}
