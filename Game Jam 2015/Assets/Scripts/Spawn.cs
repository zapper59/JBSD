﻿using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	GameObject[] spheres = new GameObject[100];
	float spawnDistance = 25f;
	float destroyDistance = 50f;
	public GameObject prefab;
	
	float smallStand = .9f;
	float smaller = .04f;
	float same = .03f;
	float larger = .02f;
	float hugeStand = .01f;

	void Start()
	{
		spawnDistance /= 5;
		for(int i = 0; i < spheres.Length; i++) {
			if(spheres[i] == null)
			{
				spheres[i] = spawnNew();
			}
		}
		spawnDistance *= 5;
	}

	// Update is called once per frame
	void FixedUpdate () {
		for(int i = 0; i < spheres.Length; i++) {
			if(spheres[i] == null)
			{
				spheres[i] = spawnNew();
			} else if(Vector3.Distance(spheres[i].transform.position, this.transform.position) > destroyDistance){
				Destroy(spheres[i]);
				spheres[i] = spawnNew();
			}
		}
	}

	GameObject spawnNew()
	{
		Vector3 randomLoc = Random.onUnitSphere;
		randomLoc = new Vector3(randomLoc.x * spawnDistance + this.transform.position.x, randomLoc.y * spawnDistance + this.transform.position.y, randomLoc.z * spawnDistance + this.transform.position.z);

		GameObject newSphere = Instantiate(prefab, randomLoc, Quaternion.identity) as GameObject;
		float size = 1;

		float rand = Random.value;
		if(rand < smallStand)
		{
			size = .5f;
			newSphere.GetComponent<AI>().disable = true;
			Debug.Log("1");
		}else if(rand < smallStand + smaller){
			size = .7f * this.transform.lossyScale.x;
			Debug.Log("2");
		}else if(rand < smallStand + smaller + same){
			size = this.transform.lossyScale.x;
			Debug.Log("3");
		}else if(rand < smallStand + smaller + same + larger){
			size = 1.3f * this.transform.lossyScale.x;
			Debug.Log("4");
		}else if(rand < smallStand + smaller + same + larger + hugeStand){
			size = 5;
			Debug.Log("5");
		}
		size *= (float)(Random.value+.5);

		newSphere.transform.localScale = new Vector3(size,size,size);

		newSphere.GetComponent<MeshRenderer>().material.mainTexture = this.GetComponent<Textures>().getRandomTexture();

		return newSphere;
	}
}
