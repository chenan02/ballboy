using UnityEngine;
using System.Collections;

public class StreakerController : MonoBehaviour {
	private Transform myTransform;
	public int moveSpeed;
	private bool movingForward;
	
	void Awake() {
		myTransform = transform;
		movingForward = true;
	}
	
	void Update() {
		if (movingForward) {
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		} else {
			myTransform.position -= myTransform.forward * moveSpeed * Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Wall")) {
			movingForward = !movingForward;
		}
	}
}
