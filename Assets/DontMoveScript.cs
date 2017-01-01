using UnityEngine;
using System.Collections;

public class DontMoveScript : MonoBehaviour {

	private float xPos;
	private float yPos;
	private float zPos;
	private Player player;
	
	// Use this for initialization
	void Start () {
		xPos = transform.position.x;
		yPos = transform.position.y;
		zPos = transform.position.z;
	}
	
	void OnCollision2D(Collision col) {
		Vector3 vectorPos = new Vector3(xPos, yPos, zPos);
		transform.position = vectorPos;
		player = GameObject.FindObjectOfType<Player>() as Player;
		print ("collided");

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Debug.DrawRay(transform.position, player.getDir());
		Vector3 dirVector = player.getDir() * player.getSpeed() * Time.deltaTime;
		Ray predRay = new Ray(transform.position, dirVector); 
		if(Physics.Raycast(transform.position, dirVector, out hit, player.getSpeed(), 0)) {
			if(hit.collider.tag == "Rock") {
				player.setSpeed(0);
			}
		}
	}
}
