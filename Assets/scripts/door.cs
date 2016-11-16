using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	float opened = -1;
	// Use this for initialization
	void Start () {
	
	}

	void Open(){
		this.transform.position = new Vector3(transform.position.x,-transform.position.y,transform.position.z);
		opened = 5;
	}

	void Close(){
		this.transform.position = new Vector3(transform.position.x,-transform.position.y,transform.position.z);
	}
	// Update is called once per frame
	void Update () {
		if (opened > 1) {
			opened -= Time.deltaTime;
		} else {
			if (opened > 0) {
				Close();
				opened = -1;
			}
		}
	}
}
