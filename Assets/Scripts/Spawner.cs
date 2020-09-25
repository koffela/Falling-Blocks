using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	//get access to the prefab
	public GameObject fallingBlockPrefab;
	//create a timer between spawns
	public float secondsBetweenSpawns = 1;
	//next spawn time starts at zero?
	float nextSpawnTime;

	Vector2 screenHalfSizeWorldUnits;

    // Start is called before the first frame update
    void Start()
    {
		//get world size (x, y)
		screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
		//if the time that's passed is greater that the next spawn time (starting at zero?) then 
		if (Time.time > nextSpawnTime)
		{
			//the next block will spawn at 1 second
			nextSpawnTime = Time.time + secondsBetweenSpawns;
			Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize/2f);
			Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.identity);
		}
    }
}
