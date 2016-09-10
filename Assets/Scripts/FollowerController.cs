using UnityEngine;
using System.Collections;

public class FollowerController : EnemyController {
	private Transform target;
	private Transform myTransform;
	public int moveSpeed;
	public int rotationSpeed;

	void Awake() {
		myTransform = transform;
	}

	void Start() {
		target = GameObject.FindWithTag ("Player").transform;
	}

	void Update() {
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
		                                        Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
		
		
		//move towards the player
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		
	}
}
