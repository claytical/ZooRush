﻿using UnityEngine;
using System.Collections;

public class ImmovableObjectWithReaction : ObjectModel
{
	public string Reaction; //TODO: Make trash can say "Fall"
	private bool touched;
	void Start ()
	{
		touched = false;
		GetComponentInChildren<CollisionDetect> ().objectModel = this;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	protected override void resetOtherValues ()
	{
		
	}

	public override void collisionDetected ()
	{
	}
	
	public override void interactWithCharacter (Collider2D character)
	{
		if (!touched) {
			if (character.transform.position.y < -2.5f) {
				character.rigidbody2D.AddForce (new Vector2 (-350f, 50f));
			} else {
				character.rigidbody2D.AddForce (new Vector2 (-350f, -50f));
			}
			gameObject.GetComponent<Animator> ().SetTrigger (Reaction);
		}
		touched = true;
	}
}