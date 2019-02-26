using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


	private const float DEFAULT_SPEED = 3.0f;	
	private const float JUMP_FORCE = 6.0f;
	private const float FALL_MULT = 2.5f;

	Rigidbody _thisRigidBody;
	public GameObject _Box;
	public GameObject _Laser;

	private bool _isGrounded = true;


	// Use this for initialization
	void Start () {
		_thisRigidBody = GetComponent<Rigidbody> ();
		//_controller    = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		float horizontalInput = Input.GetAxis ("Horizontal");
		transform.Translate (horizontalInput * Time.deltaTime * DEFAULT_SPEED, 0, 0);
		//_Box.transform.Translate (horizontalInput * Time.deltaTime * DEFAULT_SPEED, 0, 0);
		_Box.transform.position = new Vector3 ( this.transform.position.x, _Box.transform.position.y, _Box.transform.position.z);
		_Laser.transform.position = new Vector3 ( this.transform.position.x, _Laser.transform.position.y ,_Laser.transform.position.z);
		//_Laser.transform.Translate (0, -horizontalInput * Time.deltaTime * DEFAULT_SPEED, 0);

		if (Input.GetButtonDown ("Jump") && _isGrounded) {
			Debug.Log ("JUMP");
			_thisRigidBody.AddForce (new Vector3 (0, JUMP_FORCE * _thisRigidBody.mass, 0), ForceMode.Impulse);
			_isGrounded = false;

		}

		if (_thisRigidBody.velocity.y < 0) {
			_thisRigidBody.velocity += Vector3.up * Physics.gravity.y * (FALL_MULT-1) * Time.deltaTime;
		}

		//Debug.Log (_controller.isGrounded);
		//Debug.Log (_controller.collisionFlags);
	}	

	void OnCollisionEnter(Collision obj){
		Debug.Log ("COLLISION");
		if (obj.transform.CompareTag ("Plateform")) {
			_isGrounded = true;
		}
	}
}
