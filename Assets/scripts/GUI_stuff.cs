using UnityEngine;
using System.Collections;

public class GUI_stuff : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	/// <summary>
	/// OnGUI is called for rendering and handling GUI events.
	/// This function can be called multiple times per frame (one call per event).
	/// </summary>
	void OnGUI()
	{
		GUI.Label("Hello WORLD");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
