using UnityEngine;
using System.Collections;

public class ResizeCamera : MonoBehaviour {
	public GameObject mainCamera;
	public GameObject planet;
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

		if(this.transform.localScale.x >= nextLevelUp)
		{
			if(this.transform.localScale.x >= 32)
			{
				this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity + (this.transform.forward * Time.deltaTime * 40);
				this.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load("White") as Texture;
				if(Vector3.Distance(this.transform.position, mainCamera.transform.position) > 1000){
					Destroy(this.gameObject);
				}
			}
			else{
			mainCamera.transform.localPosition = new Vector3(0,0,mainCamera.transform.localPosition.z*2);
			nextLevelUp *= 2;
			}
		}
	}
}
