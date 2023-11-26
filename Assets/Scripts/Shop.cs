using UnityEngine;

public class Shop : MonoBehaviour {

	public TurretBlueprint fireAttacker;
	public TurretBlueprint waterAttacker;
	public TurretBlueprint grassAttacker;

	public TurretBlueprint fireChanger;
	public TurretBlueprint waterChanger;
	public TurretBlueprint grassChanger;

	private Constants.ElementTypes currElement = Constants.ElementTypes.Fire;
	private Constants.WeaponTypes currWeaponType = Constants.WeaponTypes.Attacker;

	BuildManager buildManager;

	void Start ()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectFire () 
	{
		currElement = Constants.ElementTypes.Fire;
		SetBluePrint(currElement, currWeaponType);
	}
	
	public void SelectWater () 
	{
		currElement = Constants.ElementTypes.Water;
		SetBluePrint(currElement, currWeaponType);
	}
	
	public void SelectGrass () 
	{
		currElement = Constants.ElementTypes.Grass;
		SetBluePrint(currElement, currWeaponType);
	}

	public void SelectAttacker ()
	{
		currWeaponType = Constants.WeaponTypes.Attacker;
		SetBluePrint(currElement, currWeaponType);
	}

	public void SelectElementChanger ()
	{
		currWeaponType = Constants.WeaponTypes.ElementChanger;
		SetBluePrint(currElement, currWeaponType);
	}

	void SetBluePrint (Constants.ElementTypes element , Constants.WeaponTypes weapon) {
		switch (weapon)
		{
			case Constants.WeaponTypes.Attacker:
				switch (element)
				{
					case Constants.ElementTypes.Fire:
						buildManager.SelectTurretToBuild(fireAttacker);
						break;
					case Constants.ElementTypes.Water:
						buildManager.SelectTurretToBuild(waterAttacker);
						break;
					case Constants.ElementTypes.Grass:
						buildManager.SelectTurretToBuild(grassAttacker);
						break;
				}
				break;
			case Constants.WeaponTypes.ElementChanger:
				switch (element)
				{
					case Constants.ElementTypes.Fire:
						buildManager.SelectTurretToBuild(fireChanger);
						break;
					case Constants.ElementTypes.Water:
						buildManager.SelectTurretToBuild(waterChanger);
						break;
					case Constants.ElementTypes.Grass:
						buildManager.SelectTurretToBuild(grassChanger);
						break;
				}
			break;
		}
	}

}
