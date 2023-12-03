using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgradedOnce = false;
	public bool isUpgradedTwice = false;

	private Renderer rend;
	private Color startColor;

	BuildManager buildManager;

	void Start ()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
    }

	public Vector3 GetBuildPosition ()
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown ()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (turret != null)
		{
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild)
			return;

		BuildTurret(buildManager.GetTurretToBuild());
	}

	void BuildTurret (TurretBlueprint blueprint)
	{
		if (PlayerStats.Money[blueprint.elementType] < blueprint.cost)
		{
			Debug.Log("Not enough money to build that!");
			return;
		}

		PlayerStats.Money[blueprint.elementType] -= blueprint.cost;

		GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		turretBlueprint = blueprint;

		GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Debug.Log("Turret build!");
	}

	public void UpgradeTurret ()
	{
		if (!isUpgradedOnce) 
		{
			if (PlayerStats.Money[turretBlueprint.elementType] < turretBlueprint.upgrade1Cost)
			{
				Debug.Log("Not enough money to upgrade that!");
				return;
			}

			PlayerStats.Money[turretBlueprint.elementType] -= turretBlueprint.upgrade1Cost;

			//Get rid of the old turret
			Destroy(turret);

			//Build a new one
			GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgrade1Prefab, GetBuildPosition(), Quaternion.identity);
			turret = _turret;

			GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
			Destroy(effect, 5f);

			isUpgradedOnce = true;
		} 
		else if (!isUpgradedTwice) 
		{
			if (PlayerStats.Money[turretBlueprint.elementType] < turretBlueprint.upgrade2Cost)
			{
				Debug.Log("Not enough money to upgrade that!");
				return;
			}

			PlayerStats.Money[turretBlueprint.elementType] -= turretBlueprint.upgrade2Cost;

			//Get rid of the old turret
			Destroy(turret);

			//Build a new one
			GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgrade2Prefab, GetBuildPosition(), Quaternion.identity);
			turret = _turret;

			GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
			Destroy(effect, 5f);

			isUpgradedTwice = true;
		}		

		Debug.Log("Turret upgraded!");
	}

	public void SellTurret ()
	{
		PlayerStats.Money[turretBlueprint.elementType] += turretBlueprint.GetSellAmount();

		GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Destroy(turret);
		turretBlueprint = null;
	}

	void OnMouseEnter ()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney)
		{
			rend.material.color = hoverColor;
		} else
		{
			rend.material.color = notEnoughMoneyColor;
		}

	}

	void OnMouseExit ()
	{
		rend.material.color = startColor;
    }

}
