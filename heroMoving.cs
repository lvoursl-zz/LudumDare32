using UnityEngine;
using System.Collections;

public class heroMoving : MonoBehaviour {
	
	Queue obstacles = new Queue();

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

		
			obstacles.Enqueue (cube);
			obstacles.Enqueue (cube1);
			obstacles.Enqueue (cube2);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float speed = 0.25f; // 0.25f
		//float step = 150;
		// hero moving
			GameObject.Find("FPSController").transform.position = new Vector3(
					GameObject.Find("FPSController").transform.position.x + speed,
					GameObject.Find("FPSController").transform.position.y,
					GameObject.Find("FPSController").transform.position.z);

		GameObject.Find("tina3").transform.position = new Vector3(
			GameObject.Find("tina3").transform.position.x + 0.25f,
			GameObject.Find("tina3").transform.position.y,
			GameObject.Find("tina3").transform.position.z);


		if (((Time.frameCount % 70) == 0) && (Time.frameCount > 200)){
			Debug.Log(Time.frameCount);
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.position = new Vector3(GameObject.Find("FPSController").transform.position.x + 150, 
			                                      13,
			                                      Random.Range(-42.0f, -50.0f));

			cube.transform.localScale = new Vector3(1, Random.Range(5, 10), 1);

			GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube1.transform.position = new Vector3(GameObject.Find("FPSController").transform.position.x + 150, 
			                                      13,
			                                      Random.Range(-42.0f, -50.0f));

			cube1.transform.localScale = new Vector3(1, Random.Range(5, 10), 1);

			GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube2.transform.position = new Vector3(GameObject.Find("FPSController").transform.position.x + 150, 
			                                      13,
			                                      Random.Range(-42.0f, -50.0f));

			cube2.transform.localScale = new Vector3(1, Random.Range(5, 10), 1);

			obstacles.Enqueue(cube);
			obstacles.Enqueue(cube1);
			obstacles.Enqueue(cube2);

			obstacles.Dequeue();
			obstacles.Dequeue();
			obstacles.Dequeue();

		}

		//Debug.Log(Time.frameCount);
		//Debug.Log(speed);
	}
}
