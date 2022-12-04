using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scrolling : MonoBehaviour
{
    public Rigidbody2D rb2d;
	public float force = -6f;

    void Start()
    {		
        rb2d = GetComponent<Rigidbody2D>(); 
		rb2d.velocity = new Vector2(force,0);

    }  
}
