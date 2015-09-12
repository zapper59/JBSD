using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	float moveSpeed = 1.5f;

	public bool disable = false;
	// Update is called once per frame
	void Update () {
		if(!disable)
		{
		GameObject[] obs = GameObject.FindGameObjectsWithTag("Player");
		double minDist = 30;
		GameObject close = null;
		foreach (GameObject g in obs){
			if(Vector3.Distance(this.transform.position,g.transform.position) < minDist && Vector3.Distance(this.transform.position,g.transform.position) > 0)
			{
				minDist = Vector3.Distance(this.transform.position,g.transform.position);
				close = g;
			}
		}
		if(close != null){
			if(close.transform.lossyScale.x > this.transform.lossyScale.x *.9)
			{
				//run
				float step = (((moveSpeed / this.transform.lossyScale.x) + moveSpeed)/2.0f) * -Time.deltaTime;
				this.transform.position = Vector3.MoveTowards(this.transform.position, close.transform.position, step);
			}else{
				//chase
				float step = (((moveSpeed / this.transform.lossyScale.x) + moveSpeed)/2.0f)*Time.deltaTime;
				this.transform.position = Vector3.MoveTowards(this.transform.position, close.transform.position, step);
			}
		}
		else{
			float step = (((moveSpeed / this.transform.lossyScale.x) + moveSpeed)/2.0f)*Time.deltaTime;
			this.transform.position = this.transform.position + (this.transform.forward * step);
		}
	}
	}
}
