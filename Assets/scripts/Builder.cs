using UnityEngine;
using System.Collections;

public class Builder : MonoBehaviour {
	public GameObject building,npcs;
	public GameObject player;
	public float Score = 1000;
	public Canvas start, endW, endD, stats;
	public GameObject WIN,DIED;
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	//	Instantiate(start, Vector3.zero, this.transform.rotation);
	}


	void GameStart(){
		Instantiate(building, Vector3.zero, this.transform.rotation);
		Instantiate(npcs, Vector3.zero, this.transform.rotation);
		Canvas st = FindObjectOfType<Canvas>();
		Destroy(st.gameObject);
		Vector3 pos = GameObject.FindGameObjectsWithTag("room_goal")[Random.Range(0, GameObject.FindGameObjectsWithTag("room_goal").Length)].transform.position;
		Instantiate(player, pos, this.transform.rotation);
		Time.timeScale = 1;
	}

	void Won(){
		Destroy(building.gameObject);
		Destroy(npcs.gameObject);
		Destroy(player.gameObject);
		Instantiate(endW);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0;
		
	}

	void Loss(){
		Score/= 5;
		Destroy(building.gameObject);
		Destroy(npcs.gameObject);
		Destroy(player.gameObject);			
		Instantiate(endD);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Score -= Time.deltaTime*7;
	}
}
