using UnityEngine;
using System.Collections;

public class Start_Game : MonoBehaviour {

	public GameObject newStartPrefab;
	// Use this for initialization
	void Start () {
		Instantiate(Resources.Load("Everything"), new Vector3(0,0,0), Quaternion.identity);
		Destroy(this.gameObject);
	}
}
