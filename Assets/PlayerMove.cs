using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	Vector3 currentDirection;
	static Animator anim;
	float speedConstant = 1f;
	float rot =0;
	// Use this for initialization
	void Start () {
		currentDirection = new Vector3(0, 0, 0);
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float speed = speedConstant * Time.deltaTime;
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");


		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * speed, transform.position.y, transform.position.z + Input.GetAxis("Vertical") * speed);
			currentDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);

		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * speed, transform.position.y, transform.position.z + Input.GetAxis("Vertical") * speed);
			currentDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);

		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * speed, transform.position.y, transform.position.z + Input.GetAxis("Vertical") * speed);
			currentDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);

		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * speed, transform.position.y, transform.position.z + Input.GetAxis("Vertical") * speed);
			currentDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
		}

		if (Input.GetKey(KeyCode.Space)) {
			anim.SetTrigger("jump");
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed);
		}
		//print(Input.GetAxis("Horizontal"));
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(currentDirection), 15 * Time.deltaTime); // interpolate for smooth camera motion
		transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * speed, transform.position.y, transform.position.z - (Input.GetAxis("Vertical") * speed));
		currentDirection = new Vector3(moveHorizontal, 0.0f, -moveVertical);
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(currentDirection), 15 * Time.deltaTime); // interpolate for smooth camera motion

	}
}
