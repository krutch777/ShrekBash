using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {


	public GameObject crate;
	public int maxCrates = 10;
	public int currentCrates;
	ArrayList crates;

	// Use this for initialization
	void Start() {
		crates = new ArrayList();
		GenerateCrates();
	}

	// Update is called once per frame
	void Update() {
		GenerateCrates();
		//if (Input.GetKeyDown("space")) {
		//	var position = RandomValue();
		//	print(position);
		//	crates.Add(Instantiate(crate, position, Quaternion.identity));
		//}


	}

	void GenerateCrates() {
		while (currentCrates < maxCrates) {
			var position = RandomValue();
			print(position);
			crates.Add(Instantiate(crate, position, Quaternion.identity));
			currentCrates++;
		}
	}

		Vector3 RandomValue() {
		Start:
			Vector3 val;
			while (true) {
				val = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
				foreach (GameObject g in crates) {
					if (Vector3.Distance(g.transform.position, val) < 1) goto Start;

				}
				goto Outer;
			}
		Outer:
			return val;
		}
}

