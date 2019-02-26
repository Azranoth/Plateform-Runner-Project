using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformsGeneration : MonoBehaviour {
	/*
	public class Plateform{

		public int index;
		public GameObject PlateformObj;

		public Plateform(int i, GameObject obj){
			index = i; PlateformObj = obj;
		}
	}
*/
	private const float PF_TIMER = 6.5f;
	private float _timer = 0.0f;

	public GameObject _plateformBase;
	public List<GameObject> _plateforms = new List<GameObject>();
	public Vector3 _lastPosition;

	// Use this for initialization
	void Start () {
		_lastPosition = new Vector3 (0.0f, 0.0f, 0.0f);
		for (int i = 0; i < 6; i++) {
			//_plateforms.Add(new Plateform
			GameObject tmp = Instantiate (_plateformBase, _lastPosition, Quaternion.identity);
			if (i == 6) {
				tmp.GetComponent<Plateform> ()._isLastPF = true;
			}

			_plateforms.Add (tmp);
			if (i == 0) {				
				_lastPosition += Vector3.right * 7.0f * Random.Range (1.2f, 1.5f);
			} else {
				_plateforms [i].transform.localScale = new Vector3 (_plateforms [i].transform.localScale.x * Random.Range (0.7f, 1.3f),
					_plateforms [i].transform.localScale.y,
					_plateforms [i].transform.localScale.z);
				_lastPosition += Vector3.right * _plateforms[i-1].transform.localScale.x * Random.Range (1.2f, 1.5f);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_timer < PF_TIMER) {
			_timer += 1.0f*Time.deltaTime;
		} else {
			Debug.Log ("new plateform");

			GameObject tmp = _plateforms [0];
			_plateforms.RemoveAt (0);

			_plateforms [_plateforms.Count - 1].GetComponent<Plateform> ()._isLastPF = false;
			_plateforms.Add (tmp);
			_plateforms [_plateforms.Count - 1].GetComponent<Plateform> ()._isLastPF = true;

			_plateforms [_plateforms.Count-1].transform.localScale = new Vector3 (_plateforms [_plateforms.Count-1].transform.localScale.x * Random.Range (0.7f, 1.3f),
				_plateforms [_plateforms.Count-1].transform.localScale.y,
				_plateforms [_plateforms.Count-1].transform.localScale.z);
			_plateforms [_plateforms.Count - 1].transform.position = _lastPosition;
				_lastPosition += Vector3.right * _plateforms[_plateforms.Count-1].transform.localScale.x * Random.Range (1.2f, 1.5f);

			_timer = 0.0f;
		}

	}

	public void timerReset(){
		_timer = PF_TIMER;
	}
}
