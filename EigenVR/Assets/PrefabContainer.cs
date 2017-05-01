using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabContainer : MonoBehaviour {
	public GameObject[] shapes = new GameObject[4];
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 4; i++) {
			GameObject item = GameObject.Instantiate (shapes [i], transform.GetChild (0).GetChild (0).GetChild(0));
			item.transform.localPosition = new Vector3 (-7.5f + 5f * i, 2.5f, 0);
			item.transform.localScale = new Vector3 (4f, 4f, 4f);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
