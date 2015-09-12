using UnityEngine;
using System.Collections;

public class ResizeCamera : MonoBehaviour {
	public GameObject mainCamera;
	double nextLevelUp = 2;
    float z = -2.5f;

	
	// Update is called once per frame
	void Update () {

        if (this.transform.localScale.x >= nextLevelUp)
        {
            z *= 2;
            nextLevelUp *= 2;
        }

		mainCamera.transform.localPosition = new Vector3(0,0,Mathf.Lerp(mainCamera.transform.localPosition.z, z, .1f));
	}
}
