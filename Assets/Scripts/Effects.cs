using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effects : MonoBehaviour {
	public Button bt;
	public  AudioClip backgroundSound ,jumpEffect, coinEffect,gameOver;
	public  AudioSource audioSrc, bkSrc;

	public  bool isMute = false;
	public Sprite imgSound,imgMute;


	void Start () {
		
		jumpEffect = Resources.Load<AudioClip> ("jump");
		coinEffect  = Resources.Load<AudioClip> ("coins");
		gameOver = Resources.Load<AudioClip> ("game over");
	}

	public  void playSound(string clip){
		if (!isMute) {
			switch (clip) {
			case "jump":
				audioSrc.PlayOneShot (jumpEffect);
				break;
			case "coin":
				audioSrc.PlayOneShot (coinEffect);
				break;
			case "dead":
				audioSrc.PlayOneShot (gameOver);
				bkSrc.Stop ();
				break;
	
			}
		}
	}

	public void mute(){
		Debug.Log ("mute");
		if (isMute) {
			AudioListener.pause = false;
			bt.image.sprite = imgSound;
		} else {
			bt.image.sprite = imgMute;
			AudioListener.pause = true;
		}
		isMute = !isMute;

	}
}
