using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeater : MonoBehaviour {

	BoxCollider2D bc2d;
	float groungHorizontalLength,y;

	void Start()
	{
		bc2d = GetComponent<BoxCollider2D>();
		groungHorizontalLength = bc2d.size.x;
		y= transform.position.y;

	}




	void Update()
	{
		if (transform.position.x <= -(groungHorizontalLength+26))
			transform.position =  new Vector2((groungHorizontalLength+26) ,y);
	}

}
