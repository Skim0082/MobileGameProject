using UnityEngine;
using System.Collections;

public enum PlayerStatus{
	Fly,
	Death
}

public class Player_Ctrl : MonoBehaviour {

	[SerializeField] float Accel_Power = 20f;
	[SerializeField] float FlySpeed = 20f;
	public PlayerStatus PS;
	public Vector3 moveDirection;
	[SerializeField] AudioClip[] Sound;
	[SerializeField] GameObject aSpeaker;

	public GameManager GM;

	float maxHeight = 20f;

	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody> ().WakeUp ();

		SpaceKeyFlying ();

	}

	void Start(){
		PS = PlayerStatus.Fly;
	}

	void SpaceKeyFlying(){
		
		if (Input.GetKey(KeyCode.Space) && PS != PlayerStatus.Death) {
			FlyingUp();
		}

		if (Input.touchCount > 0) {
			if(Input.GetTouch(0).phase == TouchPhase.Began ||Input.GetTouch(0).phase == TouchPhase.Stationary){
				FlyingUp();
			}
		}
	}

	void FlyingUp(){
		if(this.transform.position.y <= maxHeight){
			this.transform.Translate (Vector3.up * Accel_Power * Time.deltaTime);
		}
	}

	void GameOver(){
		PS = PlayerStatus.Death;
		SoundPlay (2);
		GM.GameOver ();
	}

	void SoundPlay(int Num){
		AudioSource.PlayClipAtPoint (Sound [Num], transform.position);
	}

	void GetItem(){
		SoundPlay (0);
		if (GM != null) {
			GM.GetItem ();
		}
	}

	void OnTriggerEnter(Collider collider){

		GetComponent<Rigidbody> ().WakeUp ();

		if (collider.gameObject.name == "Item") {
			Destroy(collider.gameObject);
			GetItem();
		}

		if (collider.gameObject.name == "DeathZone" && PS != PlayerStatus.Death) {
			GameOver();
		}
	}
}
