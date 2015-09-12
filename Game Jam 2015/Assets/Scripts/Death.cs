using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	public GameObject playerObject;
	public GameObject cameraObject;
	GameObject exit;
	public GameObject exitPrefab;
	public GameObject newStartPrefab;
	public GameObject destroyEverything;
	float startTime = -1;
	// Update is called once per frame
	void Update () {
		if(playerObject==null)
		{
			//restart the game
			if(exit == null)
			{
				if(startTime == -1)
					startTime = Time.time;
				if(Time.time - startTime > 3)
				{
					exit = Instantiate(exitPrefab, this.transform.position, Quaternion.identity) as GameObject;
					cameraObject.GetComponent<Camera>().clearFlags = CameraClearFlags.Color;

					GameObject[] ob = GameObject.FindGameObjectsWithTag("Player");
					foreach (GameObject g in ob)
						Destroy(g.gameObject);
				}
				GameObject[] obs = GameObject.FindGameObjectsWithTag("Player");
				foreach (GameObject g in obs){
					if(g!=null)
					{
						g.GetComponent<Rigidbody>().velocity= new Vector3(0,0,g.GetComponent<Rigidbody>().velocity.z + (100*Time.deltaTime));
					}
				}
			}else{
				exit.transform.localScale = new Vector3(exit.transform.localScale.x/(1+(Time.deltaTime*2)),exit.transform.localScale.x/(1+(Time.deltaTime*2)),exit.transform.localScale.x/(1+(Time.deltaTime*2)));
				if(exit.transform.localScale.x < .001f)
				{
					Instantiate(Resources.Load("Everything"), new Vector3(0,0,0), Quaternion.identity);
					Destroy(exit.gameObject);
					Destroy(destroyEverything);
					Destroy(this);
				}
			}
		}
	}
}
