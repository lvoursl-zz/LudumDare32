using UnityEngine;
using System.Collections;

public class winScreenScript : MonoBehaviour {
	void OnGUI () {
		
		GUI.Label(new Rect (400, 250, 1200, 1200), 
		          "<size=30>OOOOOH AMAZING! YOU WIN! CONGRATZ!\nIf you want to play again - click space:]</size>");
		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space"))
			Application.LoadLevel("firstscene");
	}
}
