using UnityEngine;
using System.Collections;

[System.Serializable]
public class TurretBlueprint {

	public GameObject prefab;
	public int cost;

	public GameObject upgrade1Prefab;
	public int upgrade1Cost;

	public GameObject upgrade2Prefab;
	public int upgrade2Cost;

	public int GetSellAmount ()
	{
		return cost / 2;
	}

}
