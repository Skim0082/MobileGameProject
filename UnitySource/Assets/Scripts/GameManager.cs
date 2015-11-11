using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameStatus{
	Play,
	Pause,
	End
}

public class GameManager : MonoBehaviour {

	public GameStatus GS;

	[SerializeField] Text Text_Meter;
	[SerializeField] Text Text_Item;

	[SerializeField] GameObject Final_GUI;

	[SerializeField] Text Final_Meter;
	[SerializeField] Text Final_Item;

	[SerializeField] GameObject Pause_GUI;

	[SerializeField] float Speed;
	[SerializeField] float Meter;
	[SerializeField] int Item;

	// Update is called once per frame
	void Update () {
		if (GS == GameStatus.Play) {
			Meter += Time.deltaTime * Speed;
			Text_Meter.text = string.Format("{0:N0} m", Meter);
		}	
	}

	public void GetItem(){
		Item += 1;
		Text_Item.text = string.Format("{0}", Item);
	}

	public void GameOver(){
		Final_Meter.text = string.Format("{0:N0} m", Meter);
		Final_Item.text = string.Format("{0}", Item);

		GS = GameStatus.End;
		Final_GUI.SetActive (true);
	}

	public void Replay(){
		Time.timeScale = 1f;
		Application.LoadLevel ("PlayScene");
	}

	public void GoToMain(){
		Time.timeScale = 1f;
		Application.LoadLevel ("IntroScene");	
	}

	public void Pause(){
		GS = GameStatus.Pause;
		Time.timeScale = 0f;
		Pause_GUI.SetActive (true);
	}
	
	public void Resume(){
		GS = GameStatus.Play;
		Time.timeScale = 1f;
		Pause_GUI.SetActive (false);
	}
	
	public void QuitApp(){
		Application.Quit ();
	}
}
