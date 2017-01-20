using UnityEngine;
using System.Collections;

public class BallControls : MonoBehaviour {

    bool moveUp = false;
    bool moveDown = false;

    float force = 1.0f;
    Vector2 moveVector;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        /*if (moveUp) {
            rb.AddForce(Vector2.up * force);
        }

        if(moveDown) {
            rb.AddForce();
        }*/
        float temp = 2;

        temp = (moveVector.y > 0) ? 2 : 1; 
        rb.AddForce(moveVector * force * temp, ForceMode2D.Impulse);
    }

	// Update is called once per frame
	void Update () {
        /*if (Input.GetKey(KeyCode.A))
        {
            moveUp = true;
            moveDown = false;
        }
        else if(Input.GetKey(KeyCode.D)) {
            moveUp = false;
            moveDown = true;
        } else
        {
            moveUp = false;
            moveDown = false;
        }*/

        moveVector = new Vector2(0, Input.GetAxisRaw("Vertical"));
	}

}
