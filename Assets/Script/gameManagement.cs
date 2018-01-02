using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManagement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManagementSingleton singleton = GameManagementSingleton.Instance;
		singleton.SetCoinPoint (0);	
		singleton.CurrentTime = 0.0f;
	}

	public GameObject MaxPointText;
	public GameObject PointText;
	public GameObject CurrentTimeText;
	
	// Update is called once per frame
	void Update () {
		//以下、点数表示
		GameManagementSingleton singleton = GameManagementSingleton.Instance;
		PointText.GetComponent<Text> ().text = "Point:" + singleton.GetCoinPoint ();
		singleton.CurrentTime += Time.deltaTime;
		CurrentTimeText.GetComponent<Text> ().text = "Time:" + (int)singleton.CurrentTime;
		MaxPointText.GetComponent<Text> ().text = "MaxPoint:" + singleton.MaxCoinPoint;

		if ((int)singleton.CurrentTime == 300) {
			SceneManager.LoadScene ("EndGame");
		}


		this.AnimalSpouningCount++;
		if (this.AnimalSpouningCount >= this.MaxAnimalSpouningCount) {
			this.SpounAnimalRandamUpdate ();
			this.AnimalSpouningCount = 0;
		}
		this.BombSouningCount++;
		if (this.BombSouningCount >= this.MaxBombSpouningCount) {
			this.SpounBombRandomUpdate ();
			this.BombSouningCount = 0;
		}



	
		if (Input.GetMouseButtonDown(0)) {
			var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var collition2d  = Physics2D.OverlapPoint(tapPoint);
			if (collition2d) {
				var hitObject= Physics2D.Raycast(tapPoint,-Vector2.up);
				if (hitObject) {
					Debug.Log("hit object is " + hitObject.collider.gameObject.name);
					string kind = this.CheckGameObjectAnimalOrBomb (hitObject.collider.gameObject);
					if (kind == "Animal") {
						audioSource = gameObject.GetComponents<AudioSource> ();
						audioSource [0].Play ();
						GenerateCoin (hitObject.collider.gameObject.transform.position);
						GenerateCoin (hitObject.collider.gameObject.transform.position);
						GenerateCoin (hitObject.collider.gameObject.transform.position);
						GenerateCoin (hitObject.collider.gameObject.transform.position);
						GenerateCoin (hitObject.collider.gameObject.transform.position);
						singleton = GameManagementSingleton.Instance;
						singleton.IncreaseCoinPoint (10);


					} else if (kind == "Bombs") {

						audioSource = gameObject.GetComponents<AudioSource> ();
						audioSource [1].Play ();
						singleton = GameManagementSingleton.Instance;
						singleton.SetCoinPoint(0);
					} else if (kind == "coin") {
						audioSource = gameObject.GetComponents<AudioSource> ();
						audioSource [0].Play ();
					}
				

					Destroy (hitObject.collider.gameObject);
				}
			}
		}
	}

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

	private string CheckGameObjectAnimalOrBomb(GameObject gameobject)
	{
		Debug.Log ("haroharo is" + gameobject.name);
		for (int i = 0; i < Animals.Length; i++) {
			if (Animals [i].name+"(Clone)" == gameobject.name) {
				return "Animal";
			}
		}

		for (int i = 0; i < Bombs.Length; i++) {
			if (Bombs [i].name+"(Clone)"  == gameobject.name) {
				return "Bombs";
			}
		}
		if (coin.name + "(Clone)" == gameobject.name) {
			return "coin";
		}
		return "null";
	}


	private AudioSource[] audioSource;

	public GameObject[] Animals;
	public GameObject[] Bombs;

	public GameObject coin;

	private void SpounAnimalRandamUpdate()
	{
		int SpounAnimalIndex = Random.Range (0, Animals.Length);
		Animals[SpounAnimalIndex].transform.position =
			Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),1));
		Instantiate (Animals[SpounAnimalIndex]);


	}

	private void SpounBombRandomUpdate()
	{
		int SpounBombIndex = Random.Range (0, Bombs.Length);
		Bombs[SpounBombIndex].transform.position =
			Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),1));
		Instantiate (Bombs [SpounBombIndex]);


	}

	private int MaxAnimalSpouningCount = 100;
	private int AnimalSpouningCount = 0;
	private int MaxBombSpouningCount = 100;
	private int BombSouningCount = 0;
}
