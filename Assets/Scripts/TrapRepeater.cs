using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRepeater : MonoBehaviour
{
	float x,y;
	void Start()
	{
		x = transform.position.x;
		y = transform.position.y;
	}

	void Update()
	{
		if (transform.position.x <= -25)
			transform.position =  new Vector2((46+(x/2)) , y);
	}
}
