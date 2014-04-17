/*
	Name: Roman Larionov
	Date: 10/17/2013
	Class: Behavior for the text GUI that pops up after someone wins the game.
	
	***USED BY TWO DIFFERENT GAMEOBJECTS!!***
	***P1WIN & P2WIN***
*/


using UnityEngine;
using System.Collections;

public class Winning : MonoBehaviour {
	
	public Ball ball;	//Allows the use of the ball gameObject's methods to check to see if anybody has won.
	
	// Update is called once per frame
	void Update () {
		if (ball.getPlayerOneScore() == ball.getScoreToWin()) {	//Works if player 1 has scored 10 times. Uses methods from the Ball class.
			if (this.name == "P1Win")				//Checks to see if this gameObjects name is 'P1Win'.
				guiText.text = "Player 1 has won!";	//Changes the text of P1Win to "Player 1 has won!".
		}
		
		if (ball.getPlayerTwoScore() == ball.getScoreToWin()){	//Works if player 2 has scored 10 times. Uses methods from the Ball class.
			if (this.name == "P2Win")				//Checks to see if this gameObjects name is 'P2Win'.
				guiText.text = "Player 2 has won!";	//Changes the text of P2Win to "Player 2 has won!".
		}
	}
}
