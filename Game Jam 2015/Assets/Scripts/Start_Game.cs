using UnityEngine;
using System.Collections;

public class Start_Game : MonoBehaviour {

	public GameObject newStartPrefab;
	public GameObject destroyOnStart;
	bool started = false;
	// Use this for initialization
	public void StartGame () {
		started = true;
		Destroy(destroyOnStart);
		Screen.lockCursor = true;
		Cursor.visible = false;
		Instantiate(Resources.Load("Everything"), new Vector3(0,0,0), Quaternion.identity);
	}

	void Update()
	{
		if(!started && Input.GetAxis("Fire1") > 0)
		{
			StartGame();
		}
	}
}
