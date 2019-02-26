using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {

	private const float CANON_TIMER = 2.0f;

	public GameObject _Sphere;

	private float _timer;
	// Use this for initialization
	void Start () {
		_timer = CANON_TIMER;
	}
	
	// Update is called once per frame
	void Update () {
		if (_timer > 0.0f) {
			_timer -= Time.deltaTime;
		} else {
			Instantiate (_Sphere, this.transform.position, Quaternion.identity);
			_timer = CANON_TIMER;
		}
	}
}
