﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private float _speed=15f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector2.up * _speed * Time.deltaTime);
			if (transform.position.y > 6){
				Destroy(this.gameObject);
			}
	}
}
