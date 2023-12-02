using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public TurretBlueprint fireAttacker;
	public TurretBlueprint waterAttacker;
	public TurretBlueprint grassAttacker;

	public TurretBlueprint fireChanger;
	public TurretBlueprint waterChanger;
	public TurretBlueprint grassChanger;

	public Sprite attackerFire;
	public Sprite attackerWater;
	public Sprite attackerGrass;

	public Sprite elemChangerFire;
	public Sprite elemChangerWater;
	public Sprite elemChangerGrass;

	public Button fireButton; 
	public Button waterButton;
	public Button grassButton;

	public Image attackerImage;
	public Image elemChangerImage;

	private Constants.ElementTypes currElement = Constants.ElementTypes.Fire;
	private Constants.WeaponTypes currWeaponType = Constants.WeaponTypes.Attacker;

	BuildManager buildManager;

	void Start ()
	{
		buildManager = BuildManager.instance;
		SelectElem(Constants.ElementTypes.Fire);
	}

	private void SelectElem(Constants.ElementTypes element) 
	{
		fireButton.interactable = element != Constants.ElementTypes.Fire;
		waterButton.interactable = element != Constants.ElementTypes.Water;
		grassButton.interactable = element != Constants.ElementTypes.Grass;
		
		switch (element)
		{
			case Constants.ElementTypes.Fire:
				attackerImage.sprite = attackerFire;
				elemChangerImage.sprite = elemChangerFire;
				break;
			case Constants.ElementTypes.Water:
				attackerImage.sprite = attackerWater;
				elemChangerImage.sprite = elemChangerWater;
				break;
			case Constants.ElementTypes.Grass:
				attackerImage.sprite = attackerGrass;
				elemChangerImage.sprite = elemChangerGrass;
				break;
		}

	}

	public void SelectFire () 
	{
		currElement = Constants.ElementTypes.Fire;
		SetBluePrint(currElement, currWeaponType);
		SelectElem(Constants.ElementTypes.Fire);
	}
	
	public void SelectWater () 
	{
		currElement = Constants.ElementTypes.Water;
		SetBluePrint(currElement, currWeaponType);
		SelectElem(Constants.ElementTypes.Water);

	}
	
	public void SelectGrass () 
	{
		currElement = Constants.ElementTypes.Grass;
		SetBluePrint(currElement, currWeaponType);
		SelectElem(Constants.ElementTypes.Grass);

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
