using UnityEngine;
using System.Collections;

public class Camera_Zoom : MonoBehaviour {

	public Camera camera;
	public GameObject player;

	float speed = 1f;
	float cameraSize = 5f;

	float MaxSize = 10f;
	float MinSize = -5f;
	
	// Update is called once per frame
	void Update () {

		cameraSize = 5f + player.transform.position.y;

		if (cameraSize >= MaxSize) {
			cameraSize = MaxSize;
		}
		if(cameraSize <= MinSize){
			cameraSize = MinSize;
		}

		camera.orthographicSize = Mathf.Lerp(camera.orthographicSize,cameraSize, Time.deltaTime/speed);
	}
}
