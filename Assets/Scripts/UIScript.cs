using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
	public Text _distanceText;
	public GameObject _player;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		_distanceText.text = "Traveled Distance : " + _player.transform.position.x.ToString ("F2");
	}
}

