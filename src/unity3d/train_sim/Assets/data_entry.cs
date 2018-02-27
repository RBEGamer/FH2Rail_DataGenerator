using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class data_entry : MonoBehaviour {

	public string sensor_id = "1";
	public float value = 0.0f;
	public float mult = 100.0f;


	public string get_json(){
		return "{\"sensor_id\":\"" + sensor_id.ToString () + "\",\"value\":" + ((int)value * mult) + "}";
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
