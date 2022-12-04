using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerContorller : MonoBehaviour {


	public Rigidbody2D rbPlayer,
	rbGround1,
	rbGround2,sky_1,sky_2,
	floorTrap1,
	floorTrap2,
	floorTrap3,
	floorTrap4,
	up_1,
	up_2;

	public GameObject[] coin;
	Animator anim;

	public float moveSpeed = -2f, jumpForce = 15.0f;
	public bool isDead = false, isRunning = false;
	private Vector2 tempPosition;
	private Vector2 tempRotation ;

	public Text txtScore;
	private int  score = 0;
	private float playerGravity = 3.5f;
	private GameObject[] gameOverText;
	public Effects mEffects;
	public CreateCoins mCoinsScript;


	void Start()
	{

		rbPlayer = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		gameOverText = GameObject.FindGameObjectsWithTag("gameOverText");



		gameOverText[0].GetComponent<Text>().enabled = false;
		gameOverText[1].GetComponent<Text>().enabled = false;
	
	
	}


	void Update()
	{
		coin = GameObject.FindGameObjectsWithTag ("coin");



		if (!isRunning) {
			anim.SetTrigger ("Idle");
		} else {
			anim.SetTrigger ("Run");}
		if (coin[1].transform.position.x<-23) {
			Destroy (coin[1]);
			mCoinsScript.countCoins--;
		}
		if (coin[2].transform.position.x<-23) {
			Destroy (coin[2]);
			mCoinsScript.countCoins--;
		}
		if (coin[3].transform.position.x<-23) {
			Destroy (coin[3]);
			mCoinsScript.countCoins--;
		}
		if (coin[4].transform.position.x<-23) {
			Destroy (coin[4]);
			mCoinsScript.countCoins--;
		}


		if (transform.position.y > -1.9) {
			rbPlayer.gravityScale = playerGravity;
		} else {
			rbPlayer.gravityScale = 0;
		}


		if(!isDead && Input.GetKeyDown(KeyCode.RightArrow)){
			isRunning = true;
			anim.SetTrigger("Run");
			rbPlayer.gravityScale = 0;
			moveObjects ();
		}
		if(!isDead && Input.GetKeyUp(KeyCode.RightArrow)){
			isRunning = false;
			anim.SetTrigger("Idle");
			stopObjects ();

		}
		if (!isDead && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetTrigger("Jump");
			rbPlayer.velocity = new Vector2(rbPlayer.velocity.x,jumpForce);

			mEffects.playSound ("jump");
		}
		if (!isDead && Input.GetKeyUp (KeyCode.Space)) {

			if (isRunning) {
				rbPlayer.gravityScale = 0;
					anim.SetTrigger ("Run");
			} else {
				   anim.SetTrigger("Idle");
				}
			}
		if (isDead && Input.GetKeyDown (KeyCode.Space)) {	
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}







	void OnCollisionEnter2D(Collision2D coll){
			if (coll.collider == true){ 
				if (coll.gameObject.CompareTag( "coin")) {
						mEffects.playSound ("coin");
			    	 	Destroy (coll.gameObject);
						mCoinsScript.countCoins--;
					    score++;
					 	txtScore.text = "["+score+"]";
				if (isRunning)
					moveObjects();


					} else if(coll.gameObject.CompareTag("trap")){
				if(!isDead)
					playerDied ();
						}
			}
		
	}
		

	public void playerDied(){
		isDead = true;
		anim.SetTrigger ("Dead");
		mEffects.playSound ("dead");
		gameOverText[0].GetComponent<Text>().enabled = true;
		gameOverText[1].GetComponent<Text>().enabled = true;


		stopObjects ();
		floorTrap1.velocity =Vector2.zero;
		floorTrap2.velocity =Vector2.zero;
		floorTrap3.velocity =Vector2.zero;
		floorTrap4.velocity =Vector2.zero;
		up_1.velocity =  Vector2.zero;
		up_2.velocity = Vector2.zero;

	}
	public void moveObjects(){

		rbGround1.velocity = new Vector2(moveSpeed,0);
		rbGround2.velocity =  new Vector2(moveSpeed,0);
		sky_1.velocity =  new Vector2(moveSpeed,0);
		sky_2.velocity =  new Vector2(moveSpeed,0);
		up_1.velocity =  new Vector2(moveSpeed,0);
		up_2.velocity =  new Vector2(moveSpeed,0);

	

		if (coin [1] != null) 
			coin [1].GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed,	0);
		if (coin [2] != null) 
			coin [2].GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed,	0);
		if (coin [3] != null)
			coin [3].GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed,	0);
		if (coin [4] != null) 
			coin [4].GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed,	0);
		

	
		//floorTrap.velocity = new Vector2(moveSpeed,	0);

	}

	public void stopObjects(){
		anim.SetTrigger("Idle");
		rbGround1.velocity = Vector2.zero;
		rbGround2.velocity = Vector2.zero;
		sky_1.velocity = Vector2.zero;
		sky_2.velocity = Vector2.zero;
		up_1.velocity =  Vector2.zero;
		up_2.velocity = Vector2.zero;


		if(coin[1]!=null)
			coin[1].GetComponent<Rigidbody2D>().velocity  = Vector2.zero;
		if(coin[2]!=null)
			coin[2].GetComponent<Rigidbody2D>().velocity  = Vector2.zero;
		if(coin[3]!=null)
			coin[3].GetComponent<Rigidbody2D>().velocity  = Vector2.zero;
		if(coin[4]!=null)
			coin[4].GetComponent<Rigidbody2D>().velocity  = Vector2.zero;
		
	}


	public bool getPlayerStatus(){
		Debug.Log (isRunning);
		return isRunning;
	}
}
