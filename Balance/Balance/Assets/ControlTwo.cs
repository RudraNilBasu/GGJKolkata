using UnityEngine;
using System.Collections;

public class ControlTwo : MonoBehaviour {
    
    Camera cam;
    bool cameraFixed;

    // Use this for initialization
    Rigidbody2D rb;

    float maxSpeed = 10.0f;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        cameraFixed = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(100,0));
    }

    // Update is called once per frame
    void Update () {
        if (!cameraFixed && gameObject.transform.position.x >= cam.transform.position.x) {
            cameraFixed = true;
        }

	    if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale *= -1;
        }
        //rb.velocity = Vector2.ClampMagnitude(rb.velocity, 10.0f);
        /*
        Vector2 temp;
        temp.x = rb.velocity.x;
        */
        //  
	}

    void FixedUpdate() {
        // add horizontal velocity
        Vector2 temp;
        temp.y = rb.velocity.y;
        temp.x = 2;
        rb.velocity = temp;

        if(cameraFixed) {
            Vector3 camPos=cam.transform.position;
            camPos.x = gameObject.transform.position.x;
            cam.transform.position = camPos;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="glass") {
            Debug.Log("Kill");
        }
    }
}
