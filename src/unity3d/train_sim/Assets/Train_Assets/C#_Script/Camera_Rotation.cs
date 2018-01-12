using UnityEngine;
using System.Collections;

public class Camera_Rotation : MonoBehaviour {

	Transform This_Transform ;
	float Angle_Y ;
	float Angle_Z ;
	float Temp_Horizontal ;
	float Temp_Vertical ;
	Vector2 Last_Mouse_Pos ;

	void Start () {
		This_Transform = this.transform ;
		Angle_Y = This_Transform.eulerAngles.y ;
		Angle_Z = This_Transform.eulerAngles.z ;
	}

	void Update () {
		if ( Input.GetMouseButtonDown ( 1 ) ) {
			Last_Mouse_Pos = Input.mousePosition ;
		}
		if ( Input.GetMouseButton ( 1 ) ) {
			Temp_Horizontal = ( Input.mousePosition.x - Last_Mouse_Pos.x ) * 0.1f ;
			Temp_Vertical = ( Input.mousePosition.y - Last_Mouse_Pos.y ) * 0.1f ;
			Last_Mouse_Pos = Input.mousePosition ;
		} else {
			Temp_Horizontal = 0.0f ;
			Temp_Vertical = 0.0f ;
		}
		Angle_Y += Temp_Horizontal * 3.0f ;
		Angle_Z -= Temp_Vertical * 2.0f ;
		This_Transform.rotation = Quaternion.Euler ( 0.0f , Angle_Y , Angle_Z ) ;
	}

}
