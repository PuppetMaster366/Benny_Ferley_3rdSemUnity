using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;



public class Damage : MonoBehaviour
{
	[SerializeField] private GameObject gameOverCanvas;
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			gameOverCanvas.GetComponent<GameOver>().playerHP -= 1;
		}
		
	}
}
