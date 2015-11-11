using UnityEngine;
using System.Collections;

public class SendMsg : MonoBehaviour {

	[SerializeField] GameObject Target;
	[SerializeField] string MethodName;

	public void OnMouseDown(){
		Target.SendMessage (MethodName);
	}
}
