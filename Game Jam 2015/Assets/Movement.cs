using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			this.transform.Translate(this.transform.forward * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)|| Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.Translate(-this.transform.right * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)|| Input.GetKey (KeyCode.DownArrow)) {
			this.transform.Translate(-this.transform.forward * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)|| Input.GetKey (KeyCode.RightArrow)) {
			this.transform.Translate(this.transform.right * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl)) {
			this.transform.Translate(-this.transform.up * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			this.transform.Translate(this.transform.up * Time.deltaTime);
		}
	}
}
