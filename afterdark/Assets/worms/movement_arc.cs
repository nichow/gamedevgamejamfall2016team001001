using UnityEngine;
using System.Collections;

public class movement_arc : MonoBehaviour {

    public float upThrust;
    public float rightThrust;
    public float playerThrust;
    public Rigidbody2D rb;
    public GameObject player;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * upThrust);
        rb.AddForce(transform.right * rightThrust);
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb.AddForce(player.transform.position * playerThrust);
    }
}
