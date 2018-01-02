using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Congraturation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManagementSingleton singleton = GameManagementSingleton.Instance;
		if (PlayerPrefs.GetInt ("MaxCoinPoint") < singleton.MaxCoinPoint) {
			PlayerPrefs.SetInt ("MaxCoinPoint", singleton.MaxCoinPoint);

			for (int i = 0; i < 100; i++) {
				ExecuteCongraturation ();
			}
		}
		MaxCoinPointText.GetComponent<Text>().text =  "Max Coin Point is "+PlayerPrefs.GetInt ("MaxCoinPoint");
		CurrentCoinPointText.GetComponent<Text>().text = "Current Point is" + singleton.MaxCoinPoint.ToString ();
	}

	public GameObject MaxCoinPointText;
	public GameObject CurrentCoinPointText;

	
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

	public void ReturnToStart(){
		
		SceneManager.LoadScene ("GameStartScene");
		Advertisement.Show ();

	}
}
