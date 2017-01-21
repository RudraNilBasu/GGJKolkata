using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GLow : MonoBehaviour {
    public float alphaValue,speed;
    public bool Increasing = true;
    public GameObject Enclosuer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        //GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.4191176f, 0.396674f, 0.2157223f));
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, alphaValue);
        Enclosuer.GetComponent<SpriteRenderer>().color = new Color(alphaValue, alphaValue, alphaValue, 1);
        if (Increasing)
        {
            if (alphaValue < 1)
                alphaValue += speed;
            else
                Increasing = false;
        }
        else
        {
            if (alphaValue > 0)
                alphaValue -= speed;
            else
                Increasing = true;
        }
        

    }
}
