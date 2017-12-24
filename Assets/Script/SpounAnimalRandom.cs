using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpounAnimalRandom : MonoBehaviour {




	// Use this for initialization
	void Start () {

		animals[0].transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0,0,1));
		Instantiate (animals [0]);
		this.SpounCount = this.SpounFrequency;

	}
	
	// Update is called once per frame
	void Update () {
		this.SpounAnimalRandomly ();
	}
	public GameObject[] animals;
	public GameObject[] bom;

	public void SpounAnimalRandomly()
	{
		
		animals[0].transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),1));
		Instantiate (animals [0]);
	}

	int SpounFrequency = 100;
	int SpounCount = 0;
	int AnimalBomRate;
}
