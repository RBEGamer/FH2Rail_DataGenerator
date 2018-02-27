using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpm_entry : data_entry {


	Vector3 last = Vector3.zero;
	public float time_mult = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		value = (last - this.transform.position).magnitude*Time.deltaTime*time_mult;
		last = this.transform.position;
	}
}
