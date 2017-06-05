using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

	public int damage = 1;
	public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 20); // 20sec
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
