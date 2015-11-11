using UnityEngine;
using System.Collections;

public enum PlayerStatus{
	Fly,
	Accel,
	Turbo,
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

		//KeyBoardInput ();

		//SpaceKeyAccelerate();

		SpaceKeyFlying ();

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

	void SpaceKeyAccelerate(){

		if (Input.GetKeyDown (KeyCode.Space) && PS != PlayerStatus.Death) {

			if(PS == PlayerStatus.Accel){
				Turbo();
			}
			if(PS == PlayerStatus.Fly){
				Accelerate();
			}
		}
	}
	
	void KeyBoardInput(){

		if(Input.GetKey(KeyCode.UpArrow)){

			this.transform.Translate(Vector3.up * FlySpeed * Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.DownArrow)){
			
			this.transform.Translate(Vector3.down * FlySpeed * Time.deltaTime);
		}
	}

	void Accelerate(){
		PS = PlayerStatus.Accel;
		SoundPlay (1);
		aSpeaker.SendMessage ("SoundPlay");
		GetComponent<Rigidbody> ().AddForce (new Vector3 (0, Accel_Power, 0));
	}

	void Turbo(){
		PS = PlayerStatus.Turbo;
		//SoundPlay (1);
		aSpeaker.SendMessage ("SoundPlay");
		GetComponent<Rigidbody> ().AddForce (new Vector3 (0, Accel_Power, 0));
	}

	void Fly(){
		PS = PlayerStatus.Fly;
	}

	void GameOver(){
		PS = PlayerStatus.Death;
		SoundPlay (2);
		GM.GameOver ();
	}

	void SoundPlay(int Num){
		AudioSource.PlayClipAtPoint (Sound [Num], transform.position);
	}

	void OnCollisionEnter(Collision collision){
		if (PS != PlayerStatus.Fly && PS != PlayerStatus.Death) {
			Fly ();
		}
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
