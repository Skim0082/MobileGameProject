using UnityEngine;
using System.Collections;

public class SceneMove : MonoBehaviour {

	[SerializeField] string SceneName;

	public void MoveToScene(){
		Application.LoadLevel (SceneName);
	}
}
