using UnityEngine;
using System.Collections;

public class Plateform : MonoBehaviour
{
	public bool _isLastPF = false;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter(Collision obj){
		
		if (_isLastPF && obj.transform.CompareTag ("Player")) {
			Debug.Log ("LAST PF");
			obj.gameObject.GetComponent<PlateformsGeneration> ().timerReset ();
		}
	}
}

