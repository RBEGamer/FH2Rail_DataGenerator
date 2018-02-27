using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;


public class data_publish : MonoBehaviour {
	private MqttClient client;
	public float publish_speed = 5.0f;
	private float time_curr = 5.0f;
	public GameObject[] watched_obj;
	// Use this for initialization
	void Start () {

		time_curr = publish_speed;
		//MQTT SETUP
		IPHostEntry host;
		host = Dns.GetHostEntry("marcelochsendorf.com");
		IPAddress ip = IPAddress.Parse ("18.194.104.195");
		if (host.AddressList.Length > 0) {
			ip = host.AddressList [0];
			Debug.Log ("IP ADDRES FOUND BY DNS LOOKUP - marcelochsendorf.com");
		}


		client = new MqttClient(ip, 1883, false, null);
		client.Connect("1337"); //TODO CHANGE



	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(time_curr > 0.0f){
			time_curr -= Time.deltaTime;
			if (time_curr <= 0.0f) {
				time_curr = publish_speed;
				string t = "{\"dataset\":[";

				GameObject[] go = GameObject.FindGameObjectsWithTag ("SET");
				foreach (GameObject n in go) {
					
				
					string tmp = n.GetComponent<data_entry> ().get_json ();
						Debug.Log (tmp);
					t += tmp + ",";
					client.Publish("fh2trail_s2m", System.Text.Encoding.UTF8.GetBytes(tmp), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

							}
				t += "]}";
					//client.Publish("fh2trail_s2m", System.Text.Encoding.UTF8.GetBytes(t), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
				
			}
		}

		//
	}
}
