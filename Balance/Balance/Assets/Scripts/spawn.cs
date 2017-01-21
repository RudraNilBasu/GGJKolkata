using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {

    [SerializeField]
    GameObject[] obj;

    float spawnMin = 1f;
    float spawnMax = 2f;

	// Use this for initialization
	void Start () {
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn()
    {
        Instantiate(obj[Random.Range(0,obj.Length)], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
