using UnityEngine;
using System.Collections;

public class MainTexture : MonoBehaviour {
	public Texture[] textures;
	MeshRenderer rend = null;
	float scrollSpeed = .01f;
	// Use this for initialization
	void Start () {
		int num = Random.Range(0,textures.Length);
		rend = this.GetComponent<MeshRenderer>();
		rend.material.mainTexture = textures[num];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float offset = Time.time * scrollSpeed;
		rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
