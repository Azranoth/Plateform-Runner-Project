using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour {

	Material _thisMat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider obj){
		Debug.Log ("COLLIDE");
		if(obj.CompareTag("Sphere")){
			Debug.Log ("SPHERE");
		}
		if(obj.CompareTag("Player")){			
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
	}
}
