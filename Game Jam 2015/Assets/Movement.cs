using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKey (KeyCode.W)) {
			this.transform.Translate(this.transform.forward * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			this.transform.Translate(-this.transform.right * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) {
			this.transform.Translate(-this.transform.forward * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) {
			this.transform.Translate(this.transform.right * Time.deltaTime);
		}
	}
}
