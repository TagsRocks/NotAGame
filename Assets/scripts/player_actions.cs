using UnityEngine;
using System.Collections;

public class player_actions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		
	}

	/// <summary>
	/// OnTriggerStay is called once per frame for every Collider other
	/// that is touching the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerStay(Collider other)
	{
		if(other.tag.Equals("elevator")){
			if(Input.GetKeyDown(KeyCode.Alpha1)){
				other.SendMessage("go1");
			}
			if(Input.GetKeyDown(KeyCode.Alpha2)){
				other.SendMessage("go2");
			}
			if(Input.GetKeyDown(KeyCode.Alpha3)){
				other.SendMessage("go3");
			}
			if(Input.GetKeyDown(KeyCode.Alpha4)){
				other.SendMessage("go4");
			}
		}
		if(other.tag.Equals("alarm_button")){
			if(Input.GetKeyDown(KeyCode.E)){
				other.SendMessage("Alarm");
			}
		}
	}

	/// <summary>
	/// OnTriggerExit is called when the Collider other has stopped touching the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerExit(Collider other)
	{
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
