using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//set the speed of the player
	public float speed = 7;

	float screenHalfWidthInWorldUnits;
    // Start is called before the first frame update
    void Start()
    {
		//since the player width needs to be taken into account when going off screen...
		float halfPlayerWidth = transform.localScale.x / 2f;
		//set the width to be camera size orthographic size
		screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;   
    }

    // Update is called once per frame
    void Update()
    {
		float inputX = Input.GetAxisRaw("Horizontal");
		float velocity = inputX * speed;
		transform.Translate(Vector2.right * velocity * Time.deltaTime);

		//if the player goes too far left, make it appear on the right
		if (transform.position.x < -screenHalfWidthInWorldUnits)
		{
			transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
		}
		//if the player goes too far right, make them appear on the left
		if (transform.position.x > screenHalfWidthInWorldUnits)
		{
			transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
		}
	}
}
