using UnityEngine;
using System.Collections;

public class Expand : MonoBehaviour {
	public GameObject mainElements;

	public GameObject camera;
	public GameObject IntroUI;
	float expandRate = 1f;
	// Update is called once per frame
	void Update () {
		if(transform.localScale.x < 9.8)
		{
			this.transform.localScale *= 1 + (expandRate * Time.deltaTime);
		}else{
			mainElements.SetActive(true);
			Destroy(camera.gameObject);
			Destroy(IntroUI);
			Destroy(this.gameObject);
		}
	}
}
