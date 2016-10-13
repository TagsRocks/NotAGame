using UnityEngine;
using System.Collections;

public class firestarter : MonoBehaviour {
    public float max;
    public float min;
    private float time;
    public GameObject fire;
    private bool b = true;
	// Use this for initialization
	void Start () {
        time = Random.value*(max-min) + min;
	}
	
	// Update is called once per frame
	void Update () {
        if (b) {
            time -= Time.deltaTime;
            if (time < 0){
                b = false;
                GameObject room = GameObject.FindGameObjectsWithTag("room_goal")[Random.Range(0, GameObject.FindGameObjectsWithTag("room_goal").Length)];
                GameObject ff = Instantiate(fire, room.transform.position, this.transform.rotation)as GameObject;
                ff.GetComponent<fire>().starter = room;
            }
        }
	}
}
