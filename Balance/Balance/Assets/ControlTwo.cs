using UnityEngine;
using System.Collections;

public class ControlTwo : MonoBehaviour {

    // Use this for initialization
    Rigidbody2D rb;
    

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale *= -1;
        }
	}

    void FixedUpdate() {
        Mathf.Clamp(-1.0f,1.0f);
    }
}
