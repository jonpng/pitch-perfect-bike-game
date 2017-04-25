using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSSound : MonoBehaviour {

	public Transform bikerack1;
	public Transform bikerack2;
	public Transform bikerack3;
	public Transform bikerack4;

	public Transform crowd1;
	public Transform crowd2;
	public Transform crowd3;
	public Transform crowd4;

	public AudioClip bikerack;
	public AudioClip crowd;
	public AudioClip beep;

	private AudioSource source;
	private bool playedbike;
	private bool playedcrowd;

	private int delay = 20;
	private float timingbike;
	private float timingcrowd;


	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		playedbike = false;
		timingbike = Time.time;
		playedcrowd = false;
		timingcrowd = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (bikerack1.position, transform.position) < 65) {
			if (timingbike < Time.time) {
				playedbike = true;
				timingbike = Time.time + delay;
			}
		} else if (Vector3.Distance (bikerack2.position, transform.position) < 65) {
			if (timingbike < Time.time) {
				playedbike = true;
				timingbike = Time.time + delay;
			}
		} else if (Vector3.Distance (bikerack3.position, transform.position) < 65) {
			if (timingbike < Time.time) {
				playedbike = true;
				timingbike = Time.time + delay;
			}
		} else if (Vector3.Distance (bikerack4.position, transform.position) < 65) {
			if (timingbike < Time.time) {
				playedbike = true;
				timingbike = Time.time + delay;
			}
		}

		if (playedbike) {
			source.PlayOneShot (beep);
			source.PlayOneShot (bikerack);
			playedbike = false;
		}

		if (Vector3.Distance (crowd1.position, transform.position) < 45) {
			if (timingcrowd < Time.time) {
				playedcrowd = true;
				timingcrowd = Time.time + delay;
			}
		} else if (Vector3.Distance (crowd2.position, transform.position) < 45) {
			if (timingcrowd < Time.time) {
				playedcrowd = true;
				timingcrowd = Time.time + delay;
			}
		} else if (Vector3.Distance (crowd3.position, transform.position) < 45) {
			if (timingcrowd < Time.time) {
				playedcrowd = true;
				timingcrowd = Time.time + delay;
			}
		} else if (Vector3.Distance (crowd4.position, transform.position) < 45) {
			if (timingcrowd < Time.time) {
				playedcrowd = true;
				timingcrowd = Time.time + delay;
			}
		}

		if (playedcrowd) {
			source.PlayOneShot (beep);
			source.PlayOneShot (crowd);
			playedcrowd = false;
		}
	}
}
