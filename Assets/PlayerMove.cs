using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	GameObject holding;
	Vector3 currentDirection;
	static Animator anim;
	public float moveSpeed = 10;
	private float moveHorizontal;
	private float moveVertical;

	void Start() {
		currentDirection = new Vector3(0, 0, 0);
		anim = GetComponent<Animator>();
	}

	void Update() {
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");
		if (Mathf.Abs(moveVertical) < .15) {
			moveVertical = 0;
		}
		if (Mathf.Abs(moveHorizontal) < .15) {
			moveHorizontal = 0;
		}

		print(transform.eulerAngles);

		keyboardControls();
		print(moveHorizontal + "   " + moveVertical);

		if (moveHorizontal != 0 || moveVertical != 0) {
			anim.SetTrigger("run");
			transform.position = new Vector3(transform.position.x + moveHorizontal * moveSpeed * Time.deltaTime, transform.position.y, transform.position.z - (moveVertical * moveSpeed * Time.deltaTime));
			transform.eulerAngles = new Vector3(0, (Mathf.Atan2(moveHorizontal, -moveVertical) * (180 / Mathf.PI)), 0);
		}
		else {
			anim.SetTrigger("idle");
		}

		if (Input.GetKey(KeyCode.B)) {
			if (holding != null) {
				Rigidbody rb = holding.GetComponent<Rigidbody>();
				rb.isKinematic = false;
				Vector3 dir = new Vector3(100, 0, 0);
				dir.Normalize();
				rb.AddForce(transform.forward * 600);
				//print(transform.eulerAngles.Normalize * );
				holding = null;

			}
		}
		if (holding != null) {
			holding.transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
		}

	}

	void keyboardControls() {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			moveHorizontal = -1f;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			moveHorizontal = 1f;
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			moveVertical = 1f;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			moveVertical = -1f;
		}
		if (Input.GetKey(KeyCode.Space)) {
			anim.SetTrigger("jump");
			GetComponent<Rigidbody>().AddForce(Vector2.up * moveSpeed);
		}
	}

	private void OnTriggerEnter(Collider other) {
		print("Chan");
		if (other.tag == "Crate") {
			holding = other.gameObject;

		}
	}


}
