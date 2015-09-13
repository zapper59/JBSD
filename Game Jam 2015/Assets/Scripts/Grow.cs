using UnityEngine;
using System.Collections;

public class Grow : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			if(this.transform.lossyScale.x * .9f > other.transform.lossyScale.x)
			{
				double thisVolume = (4.0f/3.0f)*Mathf.PI*Mathf.Pow(this.transform.lossyScale.x/2.0f,2);
				double otherVolume = (4.0f/3.0f)*Mathf.PI*Mathf.Pow(other.transform.lossyScale.x/2.0f,2);
				double newVolume = thisVolume + otherVolume;
				float newRad = (float)Mathf.Pow((float)newVolume / Mathf.PI / 4 * 3, 1.0f/2.0f) * 2.0f;
                print(newRad);
				this.transform.localScale = new Vector3(newRad, newRad, newRad);
				Destroy(other.gameObject);
			}
		}
	}
}
