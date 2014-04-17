/*
	Name: Roman Larionov
	Date: 10/17/2013
	Class: Behavior for the text GUI that keeps track of the scores for each player.
		   Stores the current score of each player into a string and then sets the text
		   element of each GUI to that score in real time.
	
	***USED BY TWO DIFFERENT GAMEOBJECTS!!***
	***TOPSCORE & BOTTEMSCORE***
*/


using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	public Ball ball;	//Allows the use of the ball gameObject's methods to change the text element of each GUI to that specific score.
	string pOneScore;	//Stores Player 1's current score.
	string pTwoScore;	//Stores Player 2's current score.
	
	// Update is called once per frame
	void Update () {
		pOneScore = ball.getPlayerOneScore().ToString();	//Gets Player 1's score as an int and converts it into a string.
		pTwoScore = ball.getPlayerTwoScore().ToString();	//Gets Player 2's score as an int and converts it into a string.
		
		if (guiText.name == "TopScore")			//Checks to see if this GUI is called 'TopScore'.
			guiText.text = pOneScore;			//Changes the text element of the GUI to be Player 1's current score.
		
		else if (guiText.name == "BottemScore") //Checks to see if this GUI is called 'BottemScore'.
			guiText.text = pTwoScore;			//Changes the text element of the GUI to be Player 2's current score.
	}
	
}
