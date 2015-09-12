using UnityEngine;
using System.Collections;

public class ResizeCamera : MonoBehaviour {
	public GameObject mainCamera;
	double nextLevelUp = 2;
	
	// Update is called once per frame
	void Update () {
		if(this.transform.localScale.x >= nextLevelUp)
		{
			mainCamera.transform.localPosition = new Vector3(0,0,mainCamera.transform.localPosition.z*2);
			nextLevelUp *= 2;
		}
	}
}
