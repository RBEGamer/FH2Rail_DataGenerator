using UnityEngine;
using System.Collections;

public class Drive_Wheel : MonoBehaviour {

	public bool Drive_Flag = true ;
	public float Max_Torque = 800.0f ;
	public float Accelerate_Rate = 200.0f ;
	public float Brake_Drag = 5.0f ;
	public float Idle_Drag = 0.1f ;

	Rigidbody This_RigidBody ;
	float Target_Torque ;
	float Current_Torque ;

	void Start () {
		This_RigidBody = this.GetComponent<Rigidbody>() ;
		This_RigidBody.maxAngularVelocity = 50.0f ;
		This_RigidBody.angularDrag = Idle_Drag ;
		// Layer settings.
		this.gameObject.layer = 8 ;
		Physics.IgnoreLayerCollision ( 0 , 8 , true ) ;
		Physics.IgnoreLayerCollision ( 8 , 8 , false ) ;
	}

	void Update () {
		// Accelerate
		if ( Drive_Flag ) {
			if ( Input.GetAxis ( "Vertical" ) > 0.0f ) {
				Target_Torque = Mathf.Lerp ( 0.0f , Max_Torque , Input.GetAxis ( "Vertical" ) ) ;
			}
		}
		// Brake
		if ( Input.GetAxis ( "Vertical" ) < 0.0f ) {
			Target_Torque = 0.0f ;
			This_RigidBody.angularDrag = -Input.GetAxis ( "Vertical" ) * Brake_Drag ;
		}
		// Idle
		if ( Input.GetAxis ( "Vertical" ) == 0.0f ) {
			Target_Torque = 0.0f ;
			This_RigidBody.angularDrag = Idle_Drag ;
		}
		//
		if ( Current_Torque < Target_Torque ) {
			Current_Torque = Mathf.MoveTowards ( Current_Torque , Target_Torque , Accelerate_Rate * Time.deltaTime ) ;
		} else if ( Current_Torque > Target_Torque ) {
			Current_Torque = Target_Torque ;
		}
	}

	void FixedUpdate () {
		GetComponent<Rigidbody>().AddRelativeTorque ( Current_Torque , 0 , 0 ) ;
	}

}
