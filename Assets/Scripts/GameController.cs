using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject follower;
	public GameObject streaker;
	public GameObject sitter;
	public Vector3 spawnValues;
	public float spawnWait;
	public GUIText gameOverText;
	public GUIText restartText;
	public GUIText scoreText;
	private int score;
	private bool gameOver;
	private bool restart;

	void Start() {
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		score = 0;
		SetScore ();
		StartCoroutine(Spawn ());
	}

	void Update() {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator Spawn() {
		while (!gameOver) {
			spawn(follower);
			if(score >= 50 && score % 5 == 0) {
				spawn(streaker);
			}
			if(score >= 100 && score % 5 == 0) {
				spawn(sitter);
			}
			score++;
			SetScore ();
			yield return new WaitForSeconds(spawnWait);
		}
		restartText.text = "Press 'R' to restart";
		restart = true;
	}

	public void GameOver() {
		gameOverText.text = "Game over!";
		gameOver = true;
	}

	void spawn(GameObject enemy) {
		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range (-spawnValues.z, spawnValues.z));
		while (enemy.CompareTag("Sitter") && (spawnPosition.x > spawnValues.x-5 || spawnPosition.x < -spawnValues.x+5 || spawnPosition.z > spawnValues.z-5 || spawnPosition.z < -spawnValues.z+5)) {
			spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range (-spawnValues.z, spawnValues.z));
		}
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (enemy, spawnPosition, spawnRotation);
	}

	void SetScore() {
		scoreText.text = "Score: " + score.ToString ();
	}
}
