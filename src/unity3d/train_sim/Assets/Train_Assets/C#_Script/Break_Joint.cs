using UnityEngine;
using System.Collections;

public class Break_Joint : MonoBehaviour {

	Transform This_Transform ;

	void Start () {
		This_Transform = this.transform ;
	}
	
	void Update () {
		if ( Mathf.Abs ( Mathf.DeltaAngle ( This_Transform.eulerAngles.z , 0.0f ) ) > 30.0f ) {
			Destroy ( GetComponent<HingeJoint>() ) ;
			Destroy ( this ) ;
		}
	}
}
