using UnityEngine;
using System.Collections;

public class Hit_Detection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("SALAD");
        if (other.tag == "Worm")
        {
            Debug.Log("FUCK");
            Destroy(gameObject);
        }
    }
}
