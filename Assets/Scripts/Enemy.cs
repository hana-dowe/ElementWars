using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;

	public Constants.ElementTypes elementType;
	
	public float speed;

	public float startHealth = 100;
	private float health;

	public int worth = 50;

	public Material materialFire;
	public Material materialWater;
	public Material materialGrass;

	public GameObject deathEffectFire;
	public GameObject deathEffectWater;
	public GameObject deathEffectGrass;

	private GameObject deathEffect;

	[Header("Unity Stuff")]
	public Image healthBar;

	private bool isDead = false;

	void Start ()
	{
		speed = startSpeed;
		health = startHealth;
		ChangeType(elementType);
	}

	public void TakeDamage (float amount, Constants.ElementTypes weaponElement)
	{
		switch (weaponElement)
		{
			case Constants.ElementTypes.Fire:
				if (elementType == Constants.ElementTypes.Water) {
					health -= amount / 4;
				}
				if (elementType == Constants.ElementTypes.Grass) {
					health -= amount;
				}
				break;
			case Constants.ElementTypes.Water:
				if (elementType == Constants.ElementTypes.Grass) {
					health -= amount / 4;
				}
				if (elementType == Constants.ElementTypes.Fire) {
					health -= amount;
				}
				break;
			case Constants.ElementTypes.Grass:
				if (elementType == Constants.ElementTypes.Fire) {
					health -= amount / 4;
				}
				if (elementType == Constants.ElementTypes.Water) {
					health -= amount;
				}
				break;
		}

		healthBar.fillAmount = health / startHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	public void ChangeType (Constants.ElementTypes newType) 
	{
		switch (newType)
		{
			case Constants.ElementTypes.Fire:
				gameObject.GetComponent<Renderer>().material = materialFire;
				deathEffect = deathEffectFire;
				break;
			case Constants.ElementTypes.Water:
				gameObject.GetComponent<Renderer>().material = materialWater;
				deathEffect = deathEffectWater;
				break;
			case Constants.ElementTypes.Grass:
				gameObject.GetComponent<Renderer>().material = materialGrass;
				deathEffect = deathEffectGrass;
				break;
		}

		elementType = newType;
	}

	public void Slow (float pct)
	{
		speed = startSpeed * (1f - pct);
	}

	void Die ()
	{
		isDead = true;

		PlayerStats.Money += worth;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}

}
