using UnityEngine;
using System.Collections;

public class Textures : MonoBehaviour {
	public Texture[] textures;

	public Texture getRandomTexture(){
		int num = Random.Range(0,textures.Length);
		return textures[num];

	}
}
