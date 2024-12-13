﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
   // Using Serializable allows us to embed a class with sub properties in the inspector.
		[Serializable]
		public class Count
		{
			public int minimum; 			//Minimum value for our Count class.
			public int maximum; 			//Maximum value for our Count class.
			
			
			//Assignment constructor.
			public Count (int min, int max)
			{
				minimum = min;
				maximum = max;
			}
		}
		
		
		public int columns = 3; 										//Number of columns in our game board.
		public int rows = 6;											//Number of rows in our game board.
		public Count vangCount = new Count (5, 9);						//Lower and upper limit for our random number of walls per level.
		public Count kimcuongCount = new Count (1, 5);						//Lower and upper limit for our random number of food items per level.
		// public Count chuotCount = new Count (1, 3);
		public Count daCount = new Count (1, 5);
		public GameObject[] vangTiles;									//Array of floor prefabs.
		public GameObject[] kimcuongTiles;									//Array of wall prefabs.
		// public GameObject[] chuotTiles;	
		public GameObject[] daTiles;									//Array of food prefabs.
		
		private Transform boardHolder;									//A variable to store a reference to the transform of our Board object.
		private List <Vector3> gridPositions = new List <Vector3> ();	//A list of possible locations to place tiles.
		
		
		//Clears our list gridPositions and prepares it to generate a new board.
		void InitialiseList ()
		{
			//Clear our list gridPositions.
			gridPositions.Clear ();
			
			//Loop through x axis (columns).
			for(int x = 0; x < columns; x++)
			{
				//Within each column, loop through y axis (rows).
				for(int y = 0; y < rows; y++)
				{
					//At each index add a new Vector3 to our list with the x and y coordinates of that position.
					gridPositions.Add (new Vector3(x, y, 0f));
				}
			}
		}
		
		//RandomPosition returns a random position from our list gridPositions.
		Vector3 RandomPosition ()
		{
			//Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
			int randomIndex = Random.Range (0, gridPositions.Count);
			
			//Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
			Vector3 randomPosition = gridPositions[randomIndex];
			
			//Remove the entry at randomIndex from the list so that it can't be re-used.
			gridPositions.RemoveAt (randomIndex);
			
			//Return the randomly selected Vector3 position.
			return randomPosition;
		}
		
		
		//LayoutObjectAtRandom accepts an array of game objects to choose from along with a minimum and maximum range for the number of objects to create.
		void LayoutObjectAtRandom (GameObject[] tileArray, int minimum, int maximum)
		{
			//Choose a random number of objects to instantiate within the minimum and maximum limits
			int objectCount = Random.Range (minimum, maximum+1);
			
			//Instantiate objects until the randomly chosen limit objectCount is reached
			for(int i = 0; i < objectCount; i++)
			{
				//Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
				Vector3 randomPosition = RandomPosition();
				
				//Choose a random tile from tileArray and assign it to tileChoice
				GameObject tileChoice = tileArray[Random.Range (0, tileArray.Length)];
				
				//Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
				Instantiate(tileChoice, randomPosition, Quaternion.identity);
			}
		}
		
		
		//SetupScene initializes our level and calls the previous functions to lay out the game board
		public void SetupScene (int level)
		{
			//Reset our list of gridpositions.
			InitialiseList ();
			
			//Instantiate a random number of wall tiles based on minimum and maximum, at randomized positions.
			LayoutObjectAtRandom (vangTiles, vangCount.minimum, vangCount.maximum);
			
			//Instantiate a random number of food tiles based on minimum and maximum, at randomized positions.
			LayoutObjectAtRandom (kimcuongTiles, kimcuongCount.minimum, kimcuongCount.maximum);
			
			//Instantiate a random number of food tiles based on minimum and maximum, at randomized positions.
			// LayoutObjectAtRandom (chuotTiles, chuotCount.minimum, chuotCount.maximum);

			//Instantiate a random number of food tiles based on minimum and maximum, at randomized positions.
			LayoutObjectAtRandom (daTiles, daCount.minimum, daCount.maximum);
		}
}
