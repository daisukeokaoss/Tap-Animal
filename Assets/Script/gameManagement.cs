using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
					Destroy (hitObject.collider.gameObject);
				}
			}
		}
	}

	public GameObject[] Animals;
	public GameObject[] Bombs;

	private void SpounAnimalRandamUpdate()
	{
		int SpounAnimalIndex = 0;//Random.Range (0, Animals.Length);
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
