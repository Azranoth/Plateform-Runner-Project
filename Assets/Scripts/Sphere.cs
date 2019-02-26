using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (new Vector3 (Random.Range(3.0f,8.0f), Random.Range(-1.0f,1.0f), 0.0f), ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -2.6f)
			Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider Obj){
		
	}
}
