using UnityEngine;
using System.Collections;

public class MainTexture : MonoBehaviour {
	public Texture[] textures;
	MeshRenderer rend = null;
	float scrollSpeed = 5f;
	// Use this for initialization
	void Start () {
		int num = Random.Range(0,textures.Length);
		rend = this.GetComponent<MeshRenderer>();
		rend.material.mainTexture = textures[num];
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Time.deltaTime* scrollSpeed;
		this.transform.RotateAround(this.transform.position,this.transform.up,offset);
	}
}
