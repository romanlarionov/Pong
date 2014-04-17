/*
	Name: Roman Larionov
	Date: 10/17/2013
	Class: Behavior for the paddles in a top-down Pong Game.
	
	***USED BY TWO DIFFERENT GAMEOBJECTS!!***
	***TOPPLAYER & BOTTEMPLAYER***
*/

using UnityEngine;
using System.Collections;

public class bPaddle : MonoBehaviour { 
	
	public int moveSpeed;	//The movement speed the paddles obide by.
	public KeyCode left;
	public KeyCode right;
	
	void Start () {
		moveSpeed = 15;	 	//Initializing the movement speed. 
	}
	
	void Update () {
		
		if (this.transform.position.x >= -6.759653f)//This float is the boundary end.	//Checks to see if the paddle is moving beyond the boundary.(Left side)
			if (Input.GetKey(left))														//Grabs input from the Left Arrow key.
				this.transform.position -= new Vector3(moveSpeed*Time.deltaTime,0,0);	//Constantly subtracts from the position based on how long the button is held down.
		
		
		if (this.transform.position.x <= 6.759653f)//This float is the boundary end.	//Checks to see if the paddle is moving beyond the boundary.(Right side)
			if (Input.GetKey(right))													//Grabs input from the Right Arrow key.
				this.transform.position += new Vector3(moveSpeed*Time.deltaTime,0,0);	//Constantly subtracts from the position based on how long the button is held down.
		
	}
}
