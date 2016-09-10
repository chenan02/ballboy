using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public float forceMult;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		float verticalForce = Input.GetAxis ("Vertical");
		float horizontalForce = Input.GetAxis ("Horizontal");
		Vector3 force = new Vector3 (horizontalForce, 0.0f, verticalForce);
		rb.AddForce (force * forceMult);
	}
}
