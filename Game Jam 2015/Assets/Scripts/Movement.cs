using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	
	float mouseSpeed = 100f;
	float moveSpeed = 2.0f;
	
	void Start() {
		Screen.lockCursor = true;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        //zoomCamera();
		if (Input.GetKeyDown ("escape")) {
			Screen.lockCursor = false;
			Cursor.visible = true;
		}
		float moveAmount = ((moveSpeed / this.transform.lossyScale.x) + moveSpeed)/2.0f;
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			this.transform.Translate(moveAmount * new Vector3(0,0,1) * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)|| Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.Translate(moveAmount * new Vector3(-1,0,0) * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)|| Input.GetKey (KeyCode.DownArrow)) {
			this.transform.Translate(moveAmount * new Vector3(0,0,-1) * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)|| Input.GetKey (KeyCode.RightArrow)) {
			this.transform.Translate(moveAmount * new Vector3(1,0,0) * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl)) {
			this.transform.Translate(new Vector3(0,-1,0) *  Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			this.transform.Translate(new Vector3(0,1,0) *  Time.deltaTime);
		}
		
		//The old control method
		/*if (Input.mousePosition.x < Screen.width / 4.0 ) {
			this.transform.RotateAround(this.transform.position, this.transform.up,-20f * Time.deltaTime);
		}else if (Input.mousePosition.x > Screen.width * 3 / 4.0 ) {
			this.transform.RotateAround(this.transform.position, this.transform.up,20f * Time.deltaTime);
		}

		if (Input.mousePosition.y < Screen.height / 4.0 ) {
			this.transform.RotateAround(this.transform.position, this.transform.right,20f * Time.deltaTime);
		}else if (Input.mousePosition.y > Screen.height * 3 / 4.0 ) {
			this.transform.RotateAround(this.transform.position, this.transform.right,-20f * Time.deltaTime);
		}*/
		
		if (Input.GetAxis ("Mouse X") > .2 || Input.GetAxis ("Mouse X") < -.2) {
			this.transform.RotateAround(this.transform.position, this.transform.up,mouseSpeed * Time.deltaTime * Input.GetAxis("Mouse X"));
		}
		
		if (Input.GetAxis ("Mouse Y") > .2 || Input.GetAxis ("Mouse Y") < -.2) {
			this.transform.RotateAround(this.transform.position, this.transform.right,-mouseSpeed * Time.deltaTime * Input.GetAxis("Mouse Y"));
		}
	}

   /* float smooth = .05f;
    float cameraZ = 5;
    void zoomCamera () {
        //Camera.main.transform.localPosition = new Vector3(0, 0, Mathf.SmoothDamp(
               // Camera.main.transform.position.z, cameraZ, smooth));
        //Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 150, smooth);
        print(Camera.main.transform.localPosition);

    }*/
}

