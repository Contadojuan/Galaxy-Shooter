using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

public float mov;
	// Use this for initialization
	void Start () {
		transform.position = new Vector2(0,0);
	}
	
	// Update is called once per frame
	void Update () {
		float movHor = Input.GetAxis("Horizontal");
		float movVer = Input.GetAxis("Vertical");
		transform.Translate(new Vector3(movHor,movVer,0)*mov*Time.deltaTime);
		
	}
}
