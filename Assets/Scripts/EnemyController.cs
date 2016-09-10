using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	private GameController gameController;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("No GameController script");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			Destroy (other.gameObject);
			gameController.GameOver();
		}
	}
}
