using UnityEngine;
using System.Collections;

public class Block_Loop : MonoBehaviour {

	public float Speed = 10;		//Obstacle speed
	public GameObject[] Block;	//Created Obstacle
	public GameObject A_Zone;	//Middle Obstacle
	public GameObject B_Zone;	//Right Obstalce
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){

		A_Zone.transform.Translate (Vector3.left * Speed * Time.deltaTime);
		B_Zone.transform.Translate (Vector3.left * Speed * Time.deltaTime);

		if (B_Zone.transform.position.x <= 0) {

			Remove (A_Zone);

			A_Zone = B_Zone;
			Create ();
		}
	}

	void Create(){

		int randomBlock = Random.Range (0, Block.Length);

		B_Zone = Instantiate (Block[randomBlock], 
		                      new Vector3 (A_Zone.transform.position.x+30, -5, 0), 
		                      transform.rotation ) as GameObject;
	}

	void Remove(GameObject Block_A){
		Destroy (Block_A);
	}

}
