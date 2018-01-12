using UnityEngine;
using System.Collections;

public class Camera_Distance : MonoBehaviour {

	Transform This_Transform ;

	void Start () {
		This_Transform = this.transform ;
	}

	void Update () {
		if ( Input.GetAxis ( "Mouse ScrollWheel" ) > 0 ) {
			This_Transform.position += This_Transform.forward * 3.0f ;
		} else if ( Input.GetAxis ( "Mouse ScrollWheel" ) < 0 ) {
			This_Transform.position -= This_Transform.forward * 3.0f ;
		}
	}

}
