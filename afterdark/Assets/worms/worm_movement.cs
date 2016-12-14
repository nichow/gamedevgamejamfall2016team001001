using UnityEngine;
using System.Collections;

public class worm_movement : MonoBehaviour {

    public float speed;
    public GameObject botLeft;
    public GameObject botRight;
	// Use this for initialization
	void Start () {
        botLeft = GameObject.FindGameObjectWithTag("botLeft");
        botRight = GameObject.FindGameObjectWithTag("botRight");
        if (transform.position.x >= 0)
            speed = -.1f;
        else
            speed = .1f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(speed, 0, 0);
        if (transform.position.x > botRight.transform.position.x ||
            transform.position.x < botLeft.transform.position.x)
        {
            Destroy(gameObject);
        }
    }

}
