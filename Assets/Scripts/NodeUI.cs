using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

	public GameObject ui;

	public Text upgradeCost;
	public Button upgradeButton;

	public Text sellAmount;

	private Node target;

	public void SetTarget (Node _target)
	{
		target = _target;

		transform.position = target.GetBuildPosition();

		if (!target.isUpgradedOnce)
		{
			upgradeCost.text = "$" + target.turretBlueprint.upgrade1Cost;
			upgradeButton.interactable = true;
		} else if (!target.isUpgradedTwice) {
			upgradeCost.text = "$" + target.turretBlueprint.upgrade2Cost;
			upgradeButton.interactable = true;
		} else
		{
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
		}

		sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

		ui.SetActive(true);
	}

	public void Hide ()
	{
		ui.SetActive(false);
	}

	public void Upgrade ()
	{
		target.UpgradeTurret();
		BuildManager.instance.DeselectNode();
	}

	public void Sell ()
	{
		target.SellTurret();
		BuildManager.instance.DeselectNode();
	}

}
