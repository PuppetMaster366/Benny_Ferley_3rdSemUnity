using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{

	[SerializeField] private Rigidbody2D playerRb;
	//[SerializeField] private Animator animator;
	[SerializeField] private GameObject bulletPrefab;

	private GameObject newBullet;
	private Vector2 worldMousePosition;
	private Vector2 shootDirection;
	private float bulletSpeed = 25f;
	private bool canShoot = true;
	private float cooldownTime = 1f;

	private float moveSpeed = 400;
	private float sprintMultiplier = 1;
	private Vector2 inputValue;

	private void Update()
	{
		worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
	private void FixedUpdate()
	{
		playerRb.velocity = inputValue * moveSpeed * sprintMultiplier * Time.deltaTime;

		//animator.SetFloat("moveValueX", inputValue.x);
		//animator.SetFloat("moveValueY", inputValue.y);
		//animator.SetFloat("moveSpeed", playerRb.velocity.magnitude);

		shootDirection = worldMousePosition - playerRb.position;
		shootDirection.Normalize();
	}

	public void Shoot(InputAction.CallbackContext context)
	{
		if (context.performed && canShoot)
		{
			newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
			newBullet.GetComponent<Rigidbody2D>().AddForce(shootDirection * bulletSpeed, ForceMode2D.Impulse);
			canShoot = false;
		}
	}

	public void Move( InputAction.CallbackContext context)
	{
		inputValue = context.ReadValue<Vector2>();
	}
}
