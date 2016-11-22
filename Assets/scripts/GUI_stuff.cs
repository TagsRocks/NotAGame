using UnityEngine;
using System.Collections;

public class GUI_stuff : MonoBehaviour {
	private string Score, time, result = "WIN";

	// Use this for initialization
	void Start () {
		Score = "Score:   " + GameObject.FindGameObjectWithTag("builder").GetComponent<Builder>().Score.ToString();
	}
	/// <summary>
	/// OnGUI is called for rendering and handling GUI events.
	/// This function can be called multiple times per frame (one call per event).
	/// </summary>
	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width/5, Screen.height/3, 500, 500), Score);
		//GUI.Label(new Rect(Screen.width/5, Screen.height/3+20, 500, 500), "Time:   " + Time.time.ToString());
	}
	// Update is called once per frame
	void Update () {
	
	}
}
