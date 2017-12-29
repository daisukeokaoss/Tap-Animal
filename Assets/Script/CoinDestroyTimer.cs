using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroyTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	private AudioSource[] audioSource;
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{						
			if (IsDistanceBetweenTwoVectorInsideDistance (Camera.main.ScreenToWorldPoint(Input.mousePosition), this.transform.position)) {
				//audioSource = gameObject.GetComponents<AudioSource> ();
				//audioSource [0].Play ();
				Destroy (gameObject);
				this.audioSource = GameObject.Find("GameManagement").GetComponents<AudioSource> ();
				this.audioSource[0].Play ();

				GameManagementSingleton singleton = GameManagementSingleton.Instance;
				singleton.IncreaseCoinPoint (10);

			}
		}
	}

	private bool IsDistanceBetweenTwoVectorInsideDistance(Vector3 A,Vector3 B)
	{
		float defX = A.x - B.x;
		float defY = A.y - B.y;
		float distance = 1;
		Debug.Log ("距離は" + Mathf.Sqrt (defX * defX + defY * defY));
		if (defX*defX+ defY*defY < distance) {
			return true;
		}
		return false;
	}

	public void OnTap()
	{
		this.audioSource = GameObject.Find("GameManager").GetComponents<AudioSource> ();
		this.audioSource[0].Play ();
	} 
}
