using UnityEngine;
using System.Collections;

public class Scroll_Mapping : MonoBehaviour {

    public float ScrollSpeed = 0.5f;
    float Target_Offset;

    // Update is called once per frame
    void Update () {
        Target_Offset += Time.deltaTime * ScrollSpeed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Target_Offset,0);
        
	}
}
