using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System;


public class Builder : MonoBehaviour {
	public GameObject building,npcs;
	public GameObject player;
	public float Score = 1000;
	public GameObject start, endW, endD, stats;
	public GameObject WIN,DIED;

	bool win, elevator;
	int call, startp, endp, time;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		//Instantiate(start, Vector3.zero, this.transform.rotation);
	}


	void GameStart(){
		Instantiate(building, Vector3.zero, this.transform.rotation);
		Instantiate(npcs, Vector3.zero, this.transform.rotation);
		Canvas st = FindObjectOfType<Canvas>();
		Destroy(st.gameObject);
		Vector3 pos = GameObject.FindGameObjectsWithTag("room_goal")[startp = UnityEngine.Random.Range(0, GameObject.FindGameObjectsWithTag("room_goal").Length)].transform.position;
		Instantiate(player, pos, this.transform.rotation);
		Time.timeScale = 1f;
	}

	void Won(){
		win = true;		
		MakeLogs();
		Destroy(building.gameObject);
		Destroy(npcs.gameObject);
		Destroy(player.gameObject);
		Instantiate(endW);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0f;
		
	}

	void Loss(){
		win = false;
		Score/= 5;
		MakeLogs();
		Destroy(building.gameObject);
		Destroy(npcs.gameObject);
		Destroy(player.gameObject);			
		Instantiate(endD);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0f;
	}
	
	void MakeLogs(){
		string path = Application.dataPath + "/../" + System.DateTime.Now.ToBinary().ToString() + ".out";
		string data = "";
		data += (win)?(1):(0);
		data += (elevator)?(1):(0);
		data += call + "_";
		data += startp + "_";
		data += endp + "_";
		data += Time.time + "_";
		//File.Create(path);
		//Debug.Log("created");
		File.WriteAllText(path, data);
		Debug.Log("write");
		
	}

	void elev(){
		elevator = true;
	}

	void Call(int a) {
		if(call != 1) {
			call = a;
		}
	}

	// Update is called once per frame
	void Update () {
		Score -= Time.deltaTime*7;
	}
}
