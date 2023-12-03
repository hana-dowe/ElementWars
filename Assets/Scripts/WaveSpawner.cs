using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;

	public GameObject[] enemies;

	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;

	public Text waveCountdownText;

	public GameManager gameManager;

	private int waveIndex = 0;

	void Start() 
	{
		countdown = 2f;
		EnemiesAlive = 0;
	}

	void Update ()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex >= waves.Length)
		{	
			StartCoroutine(SpawnRandomWave());
			countdown = timeBetweenWaves;
			return; 
		}
		else if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		EnemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}

		waveIndex++;
	}

	IEnumerator SpawnRandomWave ()
	{
		PlayerStats.Rounds++;

		EnemiesAlive = PlayerStats.Rounds;

		GameObject enemy = enemies[Random.Range(0, enemies.Length)];

		for (int i = 0; i < PlayerStats.Rounds; i++)
		{
			SpawnEnemy(enemy); 
			yield return new WaitForSeconds(1f / Random.Range(1, 5));
		}

		waveIndex++;
	}

	void SpawnEnemy (GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}

}
