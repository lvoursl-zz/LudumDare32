using UnityEngine;
using System.Collections;

public class restartScreenScript : MonoBehaviour {
	void OnGUI () {

		GUI.Label(new Rect (60, 220, 1300, 1300), 
		          "<size=33>Catch the girl up and hit her by the shoe!\nYou will run <b>faster over time</b> and you'll be able to reach her!\n" +
"<i>Move left and right by pressing A and D or arrows, hit - left mouse button</i> (however, \nyou should" + "" +
"reach girl to hit her - you will understand when you can do it)\nPress SPACE to start the game:]</size>");
	
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
