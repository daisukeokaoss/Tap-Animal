using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congraturation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ExecuteCongraturation()
	{
		var position =
			Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),1));
		GenerateCoin (position);
	}

	public GameObject coin;

	private void GenerateCoin(Vector3 position)
	{
		coin.transform.position = position;
		//coin.GetComponent<Rigidbody> ().AddForce (new Vector3 (5, 0, 0), ForceMode);
		GameObject coinObj = Instantiate (coin) as GameObject;
		int xDirection = Random.Range (-5, 5);
		int yDirection = Random.Range (-5, 20);
		coinObj.GetComponent<Rigidbody>().AddForce(new Vector3 (xDirection, yDirection, 0), ForceMode.Impulse);
		Destroy (coinObj, 5f);
	}
}
