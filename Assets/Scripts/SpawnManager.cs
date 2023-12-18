using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField] private Transform[] Spawnpoints;
	private int spawnIndex;
	[SerializeField] private GameObject enemyPrefab;
	private GameObject newEnemy;
	private float spawnTime = 0f;

	public void spawnEnemy()
	{
		spawnIndex = Random.Range(0, Spawnpoints.Length);
		newEnemy = Instantiate(enemyPrefab, Spawnpoints[spawnIndex]);
	}

	private void Update()
	{
		if (spawnTime <= 3f)
		{
			spawnTime += Time.deltaTime;
		}

		else
		{
			spawnTime = 0f;
			spawnEnemy();
		}
	}
}
