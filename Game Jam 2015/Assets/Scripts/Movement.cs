using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public GameObject planet;
	public AudioClip boostSound;
	bool boosted = false;

	float mouseSpeed = 100f;
	float moveSpeed = 2.0f;
	

	
	// Update is called once per frame
	void Update () {
        //zoomCamera();
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Screen.lockCursor = false;
			Cursor.visible = true;
		}
		float moveAmount = ((moveSpeed / this.transform.lossyScale.x) + moveSpeed)/2.0f;
		/*if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
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
		}*/
		
		if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl)) {
			this.transform.Translate(moveAmount * new Vector3(0,-1,0) *  Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			this.transform.Translate(moveAmount * new Vector3(0,1,0) *  Time.deltaTime);
		}

		if (Input.GetAxis ("Horizontal") != 0) {
			this.transform.Translate(moveAmount * new Vector3(1,0,0) * Time.deltaTime * Input.GetAxis("Horizontal"));
		}

		if (Input.GetAxis ("Vertical") != 0) {
			this.transform.Translate(moveAmount * new Vector3(0,0,1) * Time.deltaTime * Input.GetAxis("Vertical"));
		}

		if (Input.GetAxis ("Mouse X") > .2 || Input.GetAxis ("Mouse X") < -.2) {
			this.transform.RotateAround(this.transform.position, this.transform.up,mouseSpeed * Time.deltaTime * Input.GetAxis("Mouse X"));
		}else if (Mathf.Abs(Input.GetAxis ("HorizontalY")) >  .1f) {
			this.transform.RotateAround(this.transform.position, this.transform.up,mouseSpeed * Time.deltaTime * Input.GetAxis("HorizontalY"));
		}

		if (Input.GetAxis ("Mouse Y") > .2 || Input.GetAxis ("Mouse Y") < -.2) {
			this.transform.RotateAround(this.transform.position, this.transform.right,mouseSpeed * Time.deltaTime * Input.GetAxis("Mouse Y"));
		}else if (Mathf.Abs(Input.GetAxis ("VerticalY")) > .1f) {
			this.transform.RotateAround(this.transform.position, this.transform.right,mouseSpeed * Time.deltaTime * Input.GetAxis("VerticalY"));
		}

		if(Input.GetAxis("Fire1") > 0)
		{
			if(Cursor.visible)
			{
				Cursor.visible = false;
			}
			else{
				if(!boosted && planet.transform.localScale.x > 1)
				{
					this.transform.Translate(moveAmount * new Vector3(0,0,1) * .5f);
					planet.transform.localScale = new Vector3(planet.transform.localScale.x *.97f, planet.transform.localScale.x *.97f, planet.transform.localScale.x *.97f);
					GetComponent<AudioSource>().PlayOneShot(boostSound);
					boosted = true;
				}
			}
		}else{
			boosted = false;
		}

		if(Input.GetAxis("end") > 0)
		{
			this.transform.position = new Vector3(1000,1000,1000);
			planet.transform.localScale = new Vector3(36,36,36);
		}
	}
}

