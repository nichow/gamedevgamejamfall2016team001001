using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float time;
    public GameObject worm;
    public Transform top;
    public Transform botLeft;
    public Transform botRight;
	// Use this for initialization
	void Start () {
        time = Random.Range(3f, 6f);
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if(time <= 0)
            SpawnEnemy();
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition;
        float randomYPosition = Random.Range(botLeft.position.y, top.position.y);
        float randomXPosition = Random.Range(0, 100f);
        //determines which side of the screen the worm is going to spawn on
        if (randomXPosition > 50)
            spawnPosition = new Vector3(botLeft.position.x, randomYPosition, 0);
        else
            spawnPosition = new Vector3(botRight.position.x, randomYPosition, 0);
        //instantiates the worm and resets the time
        Instantiate(worm, spawnPosition, Quaternion.identity);
        time = Random.Range(.5f, 1.5f);
    }
}
