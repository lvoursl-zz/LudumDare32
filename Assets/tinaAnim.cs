using UnityEngine;
using System.Collections;

public class tinaAnim : MonoBehaviour {
	public Animator an;
	// Use this for initialization
	void Start () {
		an.speed = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		an.speed = 10.0f;
	}
}
