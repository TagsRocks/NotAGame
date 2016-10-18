using UnityEngine;
using System.Collections;

public class alarm_button : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void Alarm()
    {
        GameObject[] agent = GameObject.FindGameObjectsWithTag("agent");
        for(int i = 0; i < agent.Length; i ++)
        {
            agent[i].GetComponent<agentController>().evacuating = true;
        }
    }

	// Update is called once per frame
	void Update () {

        if (Time.time > 10f && Time.time < 11f) Alarm();
	
	}
}
