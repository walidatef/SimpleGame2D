
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoins : MonoBehaviour {
	public int countCoins = 0;
	public GameObject coin;
	private GameObject rbCoin;
	float [] positionsX =new float[4];
	public PlayerContorller mPlayer;
	float moveSpeed = -2f;
	public PlayerContorller pl;
	void Start () {

	}
	
	void Update(){ 
		
		randomPositionX ();
		while(countCoins<4){
				rbCoin = Instantiate (coin, new Vector2 (positionsX [countCoins], Random.Range (-2.5f, 9)), Quaternion.identity) as GameObject;

			countCoins++;
		}
	}

	void randomPositionX(){
		positionsX [0] = Random.Range (-10, 20);
		for (int i = 1; i < 4; i++){
			positionsX [i] = Random.Range (-10, 20);
				while(  Mathf.Abs( positionsX[i-1] - positionsX[i] ) <8){
				positionsX [i] = Random.Range (-10, 20);
				}
		}
	}


}
