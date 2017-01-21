using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pickups : MonoBehaviour
{
    float addFactor = 5.0f;
    [SerializeField]
    GameObject gm;

    [SerializeField]
    Text pickup;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Player")
        {
            // increase time
            gm.GetComponent<countdown>().timeLeft += addFactor;
            pickup.text = "+" + addFactor.ToString();
            pickup.GetComponent<Animation>().Play("pickupAnim");
            // delete stuff
            if (gameObject.transform.parent)
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
