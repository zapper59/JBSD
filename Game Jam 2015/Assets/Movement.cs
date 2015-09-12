using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			this.transform.Translate(this.transform.forward);
		}
	}
}
