﻿using UnityEngine;
using System.Collections;

public class PowerUp : ObjectModel
{
	public AudioClip clip; //Audio played when interacting with this object
	private PainIndicator painIndicator;
	private ScoreKeeper scoreKeeper; //pointer to score keeper

	private Animator animator;
	public int painPoints; // pills = 75 , water bottles = 25
	public bool isFountain; 
	private bool interacted;
	private int pillCount;

	new void Start ()
	{
		base.Start ();
		interacted = false;
		painIndicator = GameObject.FindObjectOfType<PainIndicator> ();
		scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper> ();
		animator = GetComponent<Animator> ();
		audioController = GameObject.FindObjectOfType<AudioController> ();
	}


	protected override void resetOtherValues ()
	{
		interacted = false;
		animator.SetTrigger ("Reset");
		if (isFountain) {
			collisionDetect.collider2D.isTrigger = false;
		}
		collisionDetect.resetTouch ();
	}

	private void addToScore ()
	{
		scoreKeeper.addToCount ("Water Bottle");
	}

	public override void collisionDetected ()
	{
		animator.SetTrigger ("Flash");
		if (isFountain) {
			collisionDetect.collider2D.isTrigger = true;
		}
	}

	public override void interactWithCharacter (GameObject character)
	{
		if (!interacted) {
			character.GetComponent<CharacterSpeech> ().SpeechBubbleDisplay ("Refreshing!");
			addToScore ();
			painIndicator.subtractPoints (painPoints);
			audioController.objectInteraction (clip);
			interacted = true;
		}
	}
}
