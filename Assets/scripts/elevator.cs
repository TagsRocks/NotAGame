using UnityEngine;
using System.Collections;

public class elevator : MonoBehaviour {
	float destination = 0;
	float timer;
	bool b;
	// Use this for initialization
	void Start () {
	
	}
	void go1(){
		destination = 0;
	}
	void go2(){
		destination = 3;
		timer = 10;
	}
	void go3(){
		destination = 6;
		timer = 10;
	}
	void go4(){
		destination = 9;
		timer = 10;
	}
	// Update is called once per frame
	void Update () {
		float speed = (destination - this.transform.position.y);
		if(Mathf.Abs(speed) > 0.02f) {
			speed /= Mathf.Abs(speed);
			this.transform.position += Vector3.up*speed*Time.deltaTime;
		} else {
			timer -= Time.deltaTime;
			if(timer < 0){
				go1();
			}
		}
	}
}
