/*
	Name: Roman Larionov
	Date: 10/17/2013
	Class: Behavior for the ball in a top-down Pong Game.
	
	***USED BY ONE GAMEOBJECT***
	***BALL***
*/

using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	//Initialization.
	private bool stage;		//true is bottem, false is top.
	private bool scoreMade;
	private Vector3 direction;
	private float speed;
	private float outOfBoundsx;
	private float outOfBoundsy;
		
	public int playerOneScore;
	public int playerTwoScore;
	public static int scoreToWin;
	
	
	
	void Start () {
		stage = true;			//Remembers who the ball goes to, once scored. Goes up if ball is scored in lower goal and vice versa.
		scoreMade = false;		//Remembers if the ball has gone in one of the goals (used in Update).
		scoreToWin = 10;		//The total score needed to win the game.
		playerOneScore = 0;		//Player 1 starts off with a score of 0.
		playerTwoScore = 0;		//Player 2 starts off with a score of 0.
		outOfBoundsx = 8.1f;	//Stores value of the x direction's out of bounds area.
		outOfBoundsy = 10.7f;	//Stores value of the y direction's out of bounds area.
		
		if (stage)				//Begins as true, so it always goes downwards at beginning of game. (Can probably be changed. But...Lazy)
			this.direction = new Vector3(0, -1f, 0).normalized;	//Sets the initial direction to go downwards, in a striaght line.
		
		else
			this.direction = new Vector3(0, 1f, 0).normalized;	//Sets the initial direction to go upwards, in a striaght line.
		
        this.speed = 12f * Time.deltaTime;						//Overall speed of the ball.
	}
	
	void Update () {
		
		//There are certain cases where the ball flys out of the arena and doesn't count as a score, it just keeps going.
		//This if statement prevents this by teleporting the ball back to it's starting position if it goes past the boundary.
		if ((this.transform.position.x < -outOfBoundsx) || (this.transform.position.x > outOfBoundsx) ||
			(this.transform.position.y < -outOfBoundsy) || (this.transform.position.y > outOfBoundsy)) 
			StartCoroutine(waiting());
		
		if ((playerOneScore == scoreToWin) || (playerTwoScore == scoreToWin)) //Handles the case where someone reaches ten points.
			Destroy(gameObject);			//Destroys the ball because the game is over.
		
		if (scoreMade) {					//Runs once the ball has been scored.
			scoreMade = false;				//Resets scoreMade.
			StartCoroutine(waiting());		//Allows me to make a call for the 'WaitForSeconds' class.
		}
			
		this.transform.position += direction * speed;	//Constantly adds to the direction of the ball so that it moves with a smooth motion.
	}
	
	
	//Function for when the ball hits something.
	void OnCollisionEnter(Collision collision) {		
		//BALL PHYSICS!!!
		
		Vector3 normal = collision.contacts[0].normal;	//Normal vector to the directional vector when it collides into something. 
														//(The vector in between the original and outcome vectors)
        
		direction = Vector3.Reflect(direction, normal);	//The reflection vector of the direction and normal vectors. (The outcome direction after a collision) 
		
		
		//GOAL MECHANICS!!!
		
		if (collision.collider.name == "UpperBound") {	//Checks to see if the gameObject that the ball hit was named "UpperBound"
            											//If true, then a goal has been scored on player 1 and appropriate actions need to be taken.
			
			stage = true;				//The stage of the ball changes to the upper player so when the ball is reset, it will start by going upwards.	
			scoreMade = true;			//Changed to true since a goal has been made.
			renderer.enabled = false;	//Makes the ball invisible.
			speed = 0;					//The ball doesn't need to move while it's invisible.
			playerTwoScore++;			//Player 2 has scored!!! Give 'em some love.
        }
		
        else if (collision.collider.name == "LowerBound") {		//Checks to see if the gameObject that the ball hit was named "LowerBound"
																//If true, then a goal has been scored on player 2 and appropriate actions need to be taken.
			
            stage = false;				//The stage of the ball changes to the lower player so when the ball is reset, it will start by going downwards.
			scoreMade = true;			//Changed to true since a goal has been made.
			renderer.enabled = false;	//Makes the ball invisible.
			speed = 0;					//The ball doesn't need to move while it's invisible.
			playerOneScore++;			//Player 1 has scored!!! Give 'em some love.
        }
	}
	
	
	//Function for the ball after a goal has been made.
	IEnumerator waiting() {				
		
		yield return new WaitForSeconds(1);					//Class that allows you to wait for 'x' seconds before any other action is done.
		this.transform.position = new Vector3(0, 0, 10);	//Moves the ball back to the middle of the arena.
		renderer.enabled = true;							//Makes the ball visible again.
		speed = 12f * Time.deltaTime;						//Resets the speed to its original amount.
	}
	
		
	//Getter methods. For use with the Score and Winning Classes.
	public int getPlayerOneScore() {
		return playerOneScore;
	}
	
	public int getPlayerTwoScore() {
		return playerTwoScore;
	}
	
	public int getScoreToWin() {
		return scoreToWin;
	}
}

