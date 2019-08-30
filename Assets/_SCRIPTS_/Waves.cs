using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Waves : MonoBehaviour
{
	#region singleton
	public static Waves instance;
	private void Awake()
	{
		if (instance != null)
		{
			Debug.Log("More than one wave gamemaster");
			return;
		}
		instance = this;
		WaveTracker();
	}
	#endregion

	public GameObject[] spawnerPositions;
	public GameObject[] enemies;
	public GameObject[] _spawners;
	public static int WaveLength;
	public Text waveCounter;
	public Text waveMinusOne;
	public Text wavePlusOne;
	public static int enemiesLeft = 0;
	bool allEnemiesKilled = false;
	bool isCoroutineReady = true;
	public int waveLevel = 0;
	public GameObject player;
	public Transform teleportLocation;
	void Start()
	{
		enemiesLeft = 6;
		SpawnWave();
	}


	void Update()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		enemiesLeft = enemies.Length;
		if (enemiesLeft == 0)
		{
			if (!allEnemiesKilled)
			{
				endWave();
				allEnemiesKilled = true;
			}
		}
		if (enemiesLeft == 0 && isCoroutineReady)
		{
			isCoroutineReady = false;
			StartCoroutine(nextWave());
			WaveTracker();
			StartCoroutine(teleportChar());
		}
	}
	void WaveTracker()
	{
		waveLevel += 1;
		int _wavePlusOne = waveLevel + 1;
		int _waveMinusOne = waveLevel - 1;
		waveCounter.text = waveLevel.ToString();
		waveMinusOne.text = _waveMinusOne.ToString();
		wavePlusOne.text = _wavePlusOne.ToString();
		Debug.Log(waveLevel);
	}
	void endWave()
	{
		foreach (var item in enemies)
		{
			Destroy(item);
		}

	}

	public void SpawnWave()
	{
		int randomNumber = Random.Range(1, 3);
		Debug.Log("Random spawner No : " + randomNumber);
		if (randomNumber == 1)
		{
			for (int i = 0; i < enemies.Length; i++)
			{
				Instantiate(enemies[i], spawnerPositions[0].transform.position + new Vector3(0, 20, 0), spawnerPositions[0].transform.rotation);
			}
		}

		else
		{
			for (int i = 0; i < enemies.Length; i++)
			{
				Instantiate(enemies[i], spawnerPositions[1].transform);
			}
		}
	}
	IEnumerator nextWave()
	{
		yield return new WaitForSeconds(5f);
		isCoroutineReady = true;
		SpawnWave();

	}
	IEnumerator teleportChar()
	{
		yield return new WaitForSeconds(3f);
		player.transform.position = teleportLocation.position;
	}
}
