using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour {

    [SerializeField]
    bool anticlockwise;

    [SerializeField]
    float speed = 2.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (anticlockwise)
        {
            transform.Rotate(Vector3.forward * speed);
        } else
        {
            transform.Rotate(Vector3.back * speed);
        }
	}
}
