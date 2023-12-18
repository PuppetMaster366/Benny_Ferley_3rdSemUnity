using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;



public class Damage : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 30;
    public int hit = 10;

	private void Awake()
	{
		currentHealth = maxHealth;
	}

	/*public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			currentHealth -= hit;
		}
	}*/

	public void Update()
	{
		if (currentHealth<=0)
		{
			Object.Destroy(gameObject, t: 0);
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			currentHealth -= hit;
		}
		
	}
}
