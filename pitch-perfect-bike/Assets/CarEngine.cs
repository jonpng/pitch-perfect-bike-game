using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour {

	public Transform path;
	public float maxSteerAngle = 45f;
	public WheelCollider wheelFL;
	public WheelCollider wheelFR;

	private List<Transform> nodes;
	private int currentNode = 0;

	// Use this for initialization
	void Start () {
		Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
		nodes = new List<Transform>();

		for (int i = 0; i < pathTransforms.Length; i++) {
			if (pathTransforms [i] != path.transform) {
				nodes.Add (pathTransforms [i]);
			}
		}
	}
	
	// Update is called once per frame
	private void FixedUpdate () {
		ApplySteer ();
		Drive ();
		CheckWaypointDistance ();
	}

	private void ApplySteer() {
		Vector3 relativeVector = transform.InverseTransformPoint (nodes [currentNode].position);
		relativeVector /= relativeVector.magnitude;
		float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
		wheelFL.steerAngle = newSteer;
		wheelFR.steerAngle = newSteer;
	}

	private void Drive() {
		wheelFL.motorTorque = 500f;
		wheelFR.motorTorque = 500f;
	}

	private void CheckWaypointDistance () {
		if (Vector3.Distance (transform.position, nodes [currentNode].position) < 10f) {
			if (currentNode == nodes.Count - 1) {
				currentNode = 0;
			} else {
				currentNode++;
			}
		}
	}
}
