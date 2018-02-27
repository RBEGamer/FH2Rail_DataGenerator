using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_entry : data_entry {

	float sum_time = 0.0f;
	public float time_mult = 1.0f;
	public float min_temp = 20.0f;
	public float max_temp = 70.0f;
	// Use this for initialization
	void Start () {
		
	}
	

	void Update () {
		value = 20.0f + (sum_time);
		sum_time += time_mult * Time.deltaTime;
		if (value > max_temp) {
			value = 0.0f;
			sum_time = 0.0f;
		}
	}
}
