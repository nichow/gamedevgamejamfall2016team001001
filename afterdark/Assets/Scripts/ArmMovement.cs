using UnityEngine;
using System.Collections;

public class ArmMovement : MonoBehaviour {
    public Vector3 mousePos;
    public Vector3 objectPos;
    public float angle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        mousePos = Input.mousePosition;
        mousePos.z = 5.23f;
        objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
