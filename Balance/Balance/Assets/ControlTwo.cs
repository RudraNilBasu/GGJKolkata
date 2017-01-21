using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlTwo : MonoBehaviour {
    
    public float horizontalSpeed=2f;

    Camera cam;
    bool cameraFixed;

    int doOnce = 0;
    int collideOnce = 0;

    float LevelWaitingTime = 1.0f;

    [SerializeField]
    SpriteRenderer magnetUp, magnetDown;

    [SerializeField]
    GameObject panel;

    [SerializeField]
    Text panelText;

    // Use this for initialization
    Rigidbody2D rb;

    float maxSpeed = 10.0f;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        cameraFixed = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(100,0)); // 100

        magnetUp.GetComponent<SpriteRenderer>().color = Color.black;
        magnetDown.GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Update is called once per frame
    void Update () {
        if (!cameraFixed && gameObject.transform.position.x >= cam.transform.position.x) {
            cameraFixed = true;
        }

	    if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale *= -1;
            if(rb.gravityScale>0)
            {
                magnetUp.GetComponent<SpriteRenderer>().color = Color.black;
                magnetDown.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                magnetUp.GetComponent<SpriteRenderer>().color = Color.red;
                magnetDown.GetComponent<SpriteRenderer>().color = Color.black;
            }
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
        temp.x = horizontalSpeed; // 5 or 6 will be good for fast movement
        rb.velocity = temp;

        if(cameraFixed) {
            Vector3 camPos=cam.transform.position;
            camPos.x = gameObject.transform.position.x;
            cam.transform.position = camPos;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(collideOnce!=0)
        {
            return;
        }
        collideOnce++;
        if(coll.gameObject.tag=="glass") {
            Debug.Log("Kill");
            Time.timeScale = 0.2f;
            rb.velocity = new Vector2(0,0);
            StartCoroutine(waitAndLoad(0));
        } else if (coll.gameObject.tag == "end")
        {
            Time.timeScale = 0.2f;
            StartCoroutine(waitAndLoad(1));
        }
    }

    IEnumerator waitAndLoad(int condn)
    {
        yield return new WaitForSeconds(LevelWaitingTime);
        Time.timeScale = 1.0f;
        Debug.Log("Show win screen");
        gameObject.SetActive(false);
        loadScreen(condn);
    }

    void loadScreen(int condn)
    {
        if(condn==1 && doOnce==0)
        {
            // win
            doOnce++;
            panelText.text = "Level Won";
            panel.GetComponent<Animation>().Play("panelDown");
        }
        else if(condn==0 && doOnce==0)
        {
            // loss
            doOnce++;
            panelText.text = "Level Failed";
            panel.GetComponent<Animation>().Play("panelDown");
        }
    }
}
