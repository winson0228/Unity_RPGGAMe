using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float xSpeed = 10.0f;
	public float ySpeed = 10.0f;
	private float speed = 5.0f;
	public float padding = 1.0f;
	private Vector3 dir;
	float xmin;
	float xmax;
	float ymin;
	float ymax;
	
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		Vector3 upMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
		Vector3 downMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
		ymin = downMost.y + padding;
		ymax = upMost.y - padding;
	}
	
	public void setSpeed(float f) {
		speed = f;
		}
		
	public float getSpeed() {
		return speed;
	}

	public Vector3 getDir() {
		return dir;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
			if (Input.GetKey(KeyCode.LeftArrow)) {
				dir = Vector3.left;
				speed = 5.0f;
				Vector3 moveLeft = Vector3.left * speed * Time.deltaTime;
				transform.position += moveLeft;
			} else 
			if (Input.GetKey(KeyCode.RightArrow)) {
				dir = Vector3.right;
				speed = 5.0f;
				Vector3 moveRight = Vector3.right * speed * Time.deltaTime;
				transform.position += moveRight;
			}
			float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
			transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		} else 
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) {
			
			if (Input.GetKey(KeyCode.UpArrow)) {
				dir = Vector3.up;
				speed = 5.0f;
				Vector3 moveUp = Vector3.up * speed * Time.deltaTime;
				transform.position += moveUp;
			} else 
			if (Input.GetKey(KeyCode.DownArrow)) {
				dir = Vector3.down;
				speed = 5.0f;
				Vector3 moveDown = Vector3.down * speed * Time.deltaTime;
				transform.position += moveDown;
			}
			float newY = Mathf.Clamp (transform.position.y, ymin, ymax);
			transform.position = new Vector3(transform.position.x, newY, transform.position.z);
		}
		
	}

	
	
}