using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour {

	public static Dictionary<Constants.ElementTypes, int> Money;
	public int startMoney = 20;

	public static int points;

	public static int Lives;
	public int startLives = 20;

	public static int Rounds;

	void Start ()
	{
		Money = new Dictionary<Constants.ElementTypes, int>(){
			{Constants.ElementTypes.Fire, startMoney},
			{Constants.ElementTypes.Water, startMoney},
			{Constants.ElementTypes.Grass, startMoney},
		};

		points = 0;

		Lives = startLives;

		Rounds = 0;
	}

}
