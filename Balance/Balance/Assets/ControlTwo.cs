using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlTwo : MonoBehaviour {

    [SerializeField]
    GameObject blastEffect;

    GameObject gm;

    public float horizontalSpeed=6f; // it was 2

    Camera cam;
    bool cameraFixed;

    string[] failMsg = { "Frustrated yet ?", "Annnnnd..... You had only one job", "Having fun ?", "Try harder maybe ?"};

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
        //gm = GameObject.Find("GameManager");
        Time.timeScale = 1.0f;
        cam = Camera.main;
        cameraFixed = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        //rb.AddForce(new Vector2(100,0)); // 100

        magnetUp.GetComponent<SpriteRenderer>().color = Color.black;
        magnetDown.GetComponent<SpriteRenderer>().color = Color.black;
    }

    // Update is called once per frame
    void Update () {
        if (!cameraFixed && gameObject.transform.position.x >= cam.transform.position.x) {
            cameraFixed = true;
        }

	    if(Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.gravityScale == 0)
            {
                rb.gravityScale = 1;
                GameObject.Find("GameManager").GetComponent<countdown>().startCountdown = true;
            }
            else
            {
                rb.gravityScale *= -1;
            }
            if(rb.gravityScale>0)
            {
                magnetUp.GetComponent<SpriteRenderer>().color = Color.black;
                magnetDown.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                magnetUp.GetComponent<SpriteRenderer>().color = Color.white;
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
        if (rb.gravityScale != 0)
        {
            Vector2 temp;
            temp.y = rb.velocity.y;
            temp.x = horizontalSpeed; // 5 or 6 will be good for fast movement
            rb.velocity = temp;
        }

        if(cameraFixed) {
            Vector3 camPos=cam.transform.position;
            camPos.x = gameObject.transform.position.x;
            //camPos.y = gameObject.transform.position.y;
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
        Instantiate(blastEffect, transform.position, Quaternion.identity);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.GetComponent<TrailRenderer>().enabled = false;
        if (coll.gameObject.tag=="glass") {
            // Camera Shake
            /*
            if(gm!=null)
            {
                gm.GetComponent<CameraShake>().Shake(0.02f, 0.5f);
            }
            */
            Debug.Log("Kill");
            //Time.timeScale = 0.2f;
            rb.velocity = new Vector2(0,0);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //gameObject.GetComponent<TrailRenderer>().enabled = false;
            //gameObject.transform.GetChild(0).gameObject.SetActive(false);
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
        loadScreen(condn);
        gameObject.SetActive(false);
        
    }

    int timeUpOnce = 0;

    public void timeUp()
    {
        /*
        if (timeUpOnce == 0)
        {
            panelText.text = "It blasted...... in your face!";
            panel.GetComponent<Animation>().Play("panelDown");
            Instantiate(blastEffect, transform.position, Quaternion.identity);
        }
        */
    }

    void loadScreen(int condn)
    {
        if(condn==1 && doOnce==0)
        {
            // win
            doOnce++;
            panelText.text = "YOLO, Job done!";
            panel.GetComponent<Animation>().Play("panelDown");
        }
        else if(condn==0 && doOnce==0)
        {
            // loss
            doOnce++;
            //panelText.text = "You have no idea of what you are doing :( ";
            //panelText.text = "Annnnnd..... You had only one job";
            panelText.text = failMsg[ Random.Range(0,failMsg.Length-1) ];
            Debug.Log("Playing the animation");
            panel.GetComponent<Animation>().Play("panelDown");
        }
    }
}
