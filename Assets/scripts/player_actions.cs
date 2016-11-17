using UnityEngine;
using System.Collections;

public class player_actions : MonoBehaviour {
	public GameObject builder;
	// Use this for initialization
	void Start () {
		builder = GameObject.FindGameObjectWithTag("builder");	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("elevator")){
			if(GameObject.FindGameObjectsWithTag("fire").Length > 0){
				builder.SendMessage("elev");
			}
		}
		if(other.tag.Equals("fire")){
			builder.SendMessage("Loss");
		}


		if(other.tag.Equals("exit_goal")){
			builder.SendMessage("Won", other.name);
			Debug.Log("YO WON");
		}
		
		if(other.tag.Equals("alarm_button")){
			alarmAlarm = "Press E to activate alarm button";
		}
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
		if(other.tag.Equals("door")) {
			if(Input.GetKeyDown(KeyCode.E)){
				other.SendMessage("Open");
			}
		}
	}

	/// <summary>
	/// OnTriggerExit is called when the Collider other has stopped touching the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerExit(Collider other)
	{	
		if(other.tag.Equals("alarm_button")){
			alarmAlarm = "";
		}
		
	}
	private bool call = false;
	private string str = "Press P to call any number";

	private string alarmAlarm = "";
	// Update is called once per frame
	void Update () {
		if(call) {
			builder.SendMessage("Call", 2);
			string inp = Input.inputString;
			if(inp.Equals(" ")) {
				if (str.Equals("112"))
					str = "Well done";
					GameObject.FindGameObjectWithTag("builder").GetComponent<Builder>().Score += 150;
					builder.SendMessage("Call", 1);
			}
			str += inp;
		}
		if(Input.GetKeyDown(KeyCode.P)){
			call = !call;

			str = (!call)?("Press P to call any number"):("");
		}


	}

	/// <summary>
	/// OnGUI is called for rendering and handling GUI events.
	/// This function can be called multiple times per frame (one call per event).
	/// </summary>
	void OnGUI()
	{
		GUILayout.Label(str + "\n" + alarmAlarm);

	}
}
