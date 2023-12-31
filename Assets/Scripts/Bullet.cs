using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private GameObject gameOverCanvas;
	private void Start()
	{
		gameOverCanvas = GameObject.FindWithTag("GameOver");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Destroy(collision.gameObject);
			gameOverCanvas.GetComponent<GameOver>().score += 1;
		}
		Destroy(this.gameObject);
	}
}
