using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	[SerializeField] private GameObject gameOverMenu;
	[SerializeField] private GameObject playerHPtext;
	[SerializeField] private GameObject player;

	public int playerHP;
	public int score;
	[SerializeField] private GameObject scoreText;

	private void Start()
	{
		gameOverMenu.SetActive(false);
		playerHP = 3;
		Time.timeScale = 1f;
		score = 0;
	}

	private void Update()
	{
		playerHPtext.GetComponent<TextMeshProUGUI>().text = "PlayerHP: " + playerHP;
		scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score;

		if (playerHP == 0)
		{
			gameOverMenu.SetActive(true);
			player.GetComponent<Movement> ().enabled = false;
			player.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
			player.GetComponent<PlayerInput>().enabled = false;
			Time.timeScale = 0f;
		}
	}
	public void Restart()
    {
        SceneManager.LoadScene(1);
    }
	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

}
