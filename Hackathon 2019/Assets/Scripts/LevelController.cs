﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ObjectController{
	void Reset (); 
}

public class LevelController : MonoBehaviour {

	ObjectController [] objects;
	List<ObjectController> shadows;
	public GameObject playerShadow;
	// Use this for initialization
	void Start () {
		GameObject[] o = GameObject.FindGameObjectsWithTag ("levelObject");
		objects = new ObjectController [o.Length];
		for (int i = 0; i < o.Length; i++){
			objects [i] = o [i].GetComponent<ObjectController> ();
		}
		shadows = new List<ObjectController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void BanishPlayer(List<Action> actionq, Vector3 pos){
		for (int i = 0; i < objects.Length; i++){
			objects [i].Reset ();
		}
		foreach(ObjectController shadow in shadows){
			shadow.Reset ();
		}
		GameObject newShadow = Instantiate (playerShadow, pos, Quaternion.identity);
		newShadow.GetComponent<ShadowController> ().SetActionList (actionq);
		shadows.Add (newShadow.GetComponent<ObjectController> ());
	}
}
