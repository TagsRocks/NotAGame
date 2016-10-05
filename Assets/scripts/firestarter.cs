using UnityEngine;
using System.Collections;

public class firestarter : MonoBehaviour {
    public float max;
    public float min;
    private float time;
    public GameObject fire;
	// Use this for initialization
	void Start () {
        time = Random.value*(max-min) + min;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Instantiate(fire, GameObject.FindGameObjectsWithTag("room_goal")[Random.Range(0, GameObject.FindGameObjectsWithTag("room_goal").Length)].transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
	}
}
