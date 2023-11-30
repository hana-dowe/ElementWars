using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class MoneyUI : MonoBehaviour {

	public TMP_Text MoneyText;
	public Constants.ElementTypes elementType;

	// Update is called once per frame
	void Update () {
		MoneyText.text = "$" + PlayerStats.Money[elementType].ToString();
	}
}
