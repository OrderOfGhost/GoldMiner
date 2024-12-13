using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
		private BoardManager boardScript;						//Store a reference to our BoardManager which will set up the level.
		private int level = 1;									//Current level number, expressed in game as "Day 1".
		
		
		
		
		//Awake is always called before any Start functions
		void Awake()
		{
			
			//Get a component reference to the attached BoardManager script
			boardScript = GetComponent<BoardManager>();
			
			//Call the InitGame function to initialize the first level 
			InitGame();
		}

      

		
		//Initializes the game for each level.
		void InitGame()
		{	
			//Call the SetupScene function of the BoardManager script, pass it current level number.
			boardScript.SetupScene(level);	
		}
}
