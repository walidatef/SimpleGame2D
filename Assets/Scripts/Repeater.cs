using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : MonoBehaviour
{
	BoxCollider2D bc2d;
	float groungHorizontalLength,y;

	void Start()
	{
		bc2d = GetComponent<BoxCollider2D>();
		groungHorizontalLength = bc2d.size.x;
		y= gameObject.transform.position.y;
	}


	void Update()
	{
		if (transform.position.x <= -(46))

			transform.position =  new Vector2((46) , 3.16f);
	}


}
