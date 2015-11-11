using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	[SerializeField] AudioClip aSound;

	void SoundPlay(){
		AudioSource.PlayClipAtPoint (aSound, transform.position);
	}
}
