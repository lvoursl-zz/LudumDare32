using UnityEngine;
using System.Collections;

public class heroMoving : MonoBehaviour {
	
	Queue obstacles = new Queue();
	float speed = 0.25f;
	bool canHit = false;
	bool animPlayed = false;
	bool greenFlag = false;
	int womanHP = 100;
	int frameNumAtAnim;
	int currectFrame;


	void OnGUI () {
		if (greenFlag == false) {
			GUI.Label (new Rect (20, 20, 375, 365), 
		          "<size=27>Your speed: " + speed * 100 + " m / s</size>");
		} else {
			if (Time.frameCount % 650 == 0) greenFlag = false; // 850
			GUI.Label (new Rect (20, 20, 495, 495), 
			           "<color=green><size=27>Your speed is increased by " + speed * 100 + " m / s</size></color>");
		}

		if (canHit == true) {
			
			GUI.Label(new Rect (250, 70, 950, 150), 
			          "<size=27><color=red>DESTROY WITH HEEL THIS WOMAN! CLICK THE LEFT MOUSE BUTTON</color></size>");
		}

		GUI.Label (new Rect (20, 50, 375, 365), 
		           "<size=27>Woman HP: " + womanHP + "</size>");

	
	}

	// Use this for initialization
	void Start () {
		for (int i = 1; i <= 3; i++) {

			GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube.transform.position = new Vector3 (GameObject.Find ("FPSController").transform.position.x + i * 50, 
		                                      13,
		                                      Random.Range (-42.0f, -50.0f));
		
			cube.transform.localScale = new Vector3 (1, Random.Range (5, 10), 1);
		
			GameObject cube1 = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube1.transform.position = new Vector3 (GameObject.Find ("FPSController").transform.position.x + i * 50, 
		                                       13,
		                                       Random.Range (-42.0f, -50.0f));
		
			cube1.transform.localScale = new Vector3 (1, Random.Range (5, 10), 1);
		
			GameObject cube2 = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube2.transform.position = new Vector3 (GameObject.Find ("FPSController").transform.position.x + i * 50, 
		                                       13,
		                                       Random.Range (-42.0f, -50.0f));
		
			cube2.transform.localScale = new Vector3 (1, Random.Range (5, 10), 1);

			cube.GetComponent<Renderer>().material.color = Color.gray;
			cube1.GetComponent<Renderer>().material.color = Color.gray;
			cube2.GetComponent<Renderer>().material.color = Color.gray;

			obstacles.Enqueue(cube);
			obstacles.Enqueue(cube1);
			obstacles.Enqueue(cube2);
		}
	}
	
	// Update is called once per frame
	void Update () {		

		if (womanHP <= 0)
			Application.LoadLevel ("winScreen");

		if (Mathf.Abs (GameObject.Find ("FPSController").transform.position.x - 
			GameObject.Find ("tina3").transform.position.x) > 25) {

			// endgame
			Application.LoadLevel("restartAndEnd");

		} else if (Mathf.Abs (GameObject.Find ("FPSController").transform.position.x - 
			GameObject.Find ("tina3").transform.position.x) < 2) {

			// -hp y devyshki

			//if (canHit == false) canHit = true;
		}

		// hit animation
	

		if ((Input.GetMouseButtonDown(0))/* && (canHit == true)*/) {
			/*for (int i = 1; i < 360; i++) {
				GameObject.Find("heel").transform.Translate(new Vector3(0,  0, 0.01f * Time.deltaTime));
			}

			for (int i = 1; i < 360; i++) {
				GameObject.Find("heel").transform.Translate(new Vector3(0,  0, -0.01f * Time.deltaTime));
			}*/

			if (!animPlayed) {
				animPlayed = true;
				currectFrame = Time.frameCount;
			}
		
				
			frameNumAtAnim = Time.frameCount;
			if (canHit) womanHP = womanHP - 10;
		}

		if ((animPlayed) && (Time.frameCount - currectFrame < 15)) {
			GameObject.Find("heel").transform.Translate(new Vector3(0, 0.2f, 0.07f));
		} else if ((animPlayed) && (Time.frameCount - currectFrame < 30)) {
			GameObject.Find("heel").transform.Translate(new Vector3(0,  -0.2f, -0.07f));
		} else if ((animPlayed) && (Time.frameCount - currectFrame > 29)) {
			animPlayed = false;
		}

		// moving and rules
		if (GameObject.Find ("FPSController").transform.position.x > GameObject.Find ("tina3").transform.position.x - 3) {
			GameObject.Find ("FPSController").transform.position = new  Vector3 (
										GameObject.Find ("tina3").transform.position.x - 3,
										GameObject.Find ("FPSController").transform.position.y,
										GameObject.Find ("FPSController").transform.position.z);
			// если мы догнали и можем бить
			canHit = true;

		} else {

			// hero moving
			GameObject.Find ("FPSController").transform.position = new Vector3 (
					GameObject.Find ("FPSController").transform.position.x + speed,
					GameObject.Find ("FPSController").transform.position.y,
					GameObject.Find ("FPSController").transform.position.z);

			// UP SPEED
			if (GameObject.Find ("FPSController").transform.position.x < GameObject.Find ("tina3").transform.position.x - 3) {
				if (((Time.frameCount % 500) == 0)) { // 700 
					speed = speed + 0.001f; // 0.001f
					greenFlag = true;
				}
			}
		}


		// tina moving
		if ((Time.frameCount % 20) == 0) {
			GameObject.Find("tina3").transform.position = new Vector3(
				GameObject.Find("tina3").transform.position.x + 0.25f,
				GameObject.Find("tina3").transform.position.y,
				GameObject.Find("tina3").transform.position.z + Random.Range(-0.05f, 0.05f));
		} else {
			GameObject.Find("tina3").transform.position = new Vector3(
				GameObject.Find("tina3").transform.position.x + 0.25f,
				GameObject.Find("tina3").transform.position.y,
				GameObject.Find("tina3").transform.position.z);
		}


		// obstacles generation
		if (((Time.frameCount % 70) == 0) && (Time.frameCount > 200)){

			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.position = new Vector3(GameObject.Find("FPSController").transform.position.x + 150, 
			                                      13,
			                                      Random.Range(-42.0f, -50.0f));

			cube.transform.localScale = new Vector3(1, Random.Range(5, 10), 1);



			GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube1.transform.position = new Vector3(GameObject.Find("FPSController").transform.position.x + 150  + Random.Range (5, 10), 
			                                      13,
			                                      Random.Range(-42.0f, -50.0f));

			cube1.transform.localScale = new Vector3(1, Random.Range(5, 10), 1);

			GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube2.transform.position = new Vector3(GameObject.Find("FPSController").transform.position.x + 150, 
			                                      13,
			                                      Random.Range(-42.0f, -50.0f));

			cube2.transform.localScale = new Vector3(1, Random.Range(5, 10), 1);

			cube.GetComponent<Renderer>().material.color = Color.grey;
			cube1.GetComponent<Renderer>().material.color = Color.grey;
			cube2.GetComponent<Renderer>().material.color = Color.grey;


			obstacles.Enqueue(cube);
			obstacles.Enqueue(cube1);
			obstacles.Enqueue(cube2);

			if ((Time.frameCount > 500) && ((Time.frameCount % 300) == 0))  {
				GameObject ob = (GameObject) obstacles.Peek();
				Destroy(ob.gameObject);
				obstacles.Dequeue();

				ob = (GameObject) obstacles.Peek();
				Destroy(ob.gameObject);
				obstacles.Dequeue();

				ob = (GameObject) obstacles.Peek();
				Destroy(ob.gameObject);
				obstacles.Dequeue();

			}


		}

		//Debug.Log(Time.frameCount);
		//Debug.Log(speed);
	}
}
