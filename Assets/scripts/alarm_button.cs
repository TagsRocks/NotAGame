using UnityEngine;
using System.Collections;

public class alarm_button : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void Alarm()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        GameObject[] agent = GameObject.FindGameObjectsWithTag("agent");
        for(int i = 0; i < agent.Length; i ++)
        {
            agent[i].GetComponent<agentController>().evacuating = true;
        }  
        GameObject.FindGameObjectWithTag("builder").GetComponent<Builder>().Score += 200;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
