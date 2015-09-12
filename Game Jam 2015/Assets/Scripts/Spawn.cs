using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	GameObject[] spheres = new GameObject[80];
	GameObject[] movingSpheres = new GameObject[20];
	float spawnDistance = 25f;
	float destroyDistance = 50f;
	public GameObject prefab;
	
	float smallStand = .4f;
	float smaller = .2f;
	float same = .2f;
	float larger = .15f;
	float hugeStand = .05f;

	void Start()
	{
		spawnDistance /= 2;
		for(int i = 0; i < spheres.Length; i++) {
			if(spheres[i] == null)
			{
				spheres[i] = spawnNew();
				spheres[i].GetComponent<Rigidbody>().velocity = new Vector3(0,0,-20);
			}
		}
		for(int i = 0; i < movingSpheres.Length; i++) {
			if(spheres[i] == null)
			{
				spheres[i] = spawnNewMoving();
				spheres[i].GetComponent<Rigidbody>().velocity = new Vector3(0,0,-20);
			}
		}
		spawnDistance *= 2;
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
		for(int i = 0; i < movingSpheres.Length; i++) {
			if(movingSpheres[i] == null)
			{
				movingSpheres[i] = spawnNewMoving();
			} else if(Vector3.Distance(movingSpheres[i].transform.position, this.transform.position) > destroyDistance){
				Destroy(spheres[i]);
				movingSpheres[i] = spawnNewMoving();
			}
		}
	}

	GameObject spawnNew()
	{
		Vector3 randomLoc = Random.onUnitSphere;
		randomLoc = new Vector3(randomLoc.x * spawnDistance + this.transform.position.x, randomLoc.y * spawnDistance + this.transform.position.y, randomLoc.z * spawnDistance + this.transform.position.z);

		GameObject newSphere = Instantiate(prefab, randomLoc, Quaternion.identity) as GameObject;
		float size = .5f;


		newSphere.GetComponent<AI>().disable = true;

		newSphere.transform.localScale = new Vector3(size,size,size);

		newSphere.GetComponent<MeshRenderer>().material.mainTexture = this.GetComponent<Textures>().getRandomTexture();

		return newSphere;
	}

	GameObject spawnNewMoving()
	{
		Vector3 randomLoc = Random.onUnitSphere;
		randomLoc = new Vector3(randomLoc.x * spawnDistance + this.transform.position.x, randomLoc.y * spawnDistance + this.transform.position.y, randomLoc.z * spawnDistance + this.transform.position.z);
		
		GameObject newSphere = Instantiate(prefab, randomLoc, Quaternion.identity) as GameObject;
		float size = 1;
		
		float rand = Random.value;
		if(rand < smallStand)
		{
			size = 1f;
		}else if(rand < smallStand + smaller){
			size = .7f * this.transform.lossyScale.x;
		}else if(rand < smallStand + smaller + same){
			size = this.transform.lossyScale.x;
		}else if(rand < smallStand + smaller + same + larger){
			size = 1.3f * this.transform.lossyScale.x;
		}else if(rand < smallStand + smaller + same + larger + hugeStand){
			size = 5;
		}
		size *= (float)(Random.value+.5);
		
		newSphere.transform.localScale = new Vector3(size,size,size);
		
		newSphere.GetComponent<MeshRenderer>().material.mainTexture = this.GetComponent<Textures>().getRandomTexture();
		
		return newSphere;
	}
}
