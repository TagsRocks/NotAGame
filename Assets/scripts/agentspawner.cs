using UnityEngine;
using System.Collections;

public class agentspawner : MonoBehaviour {
    public GameObject agent;
    // Use this for initialization
    void Start()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("room_goal");
        for (int i = 0; i < points.Length; i++)
        {
             Instantiate(agent, points[i].transform.position, this.transform.rotation);
            
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
