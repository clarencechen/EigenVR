using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupInfo : MonoBehaviour {
	private GameObject obj;
	public GameObject text;
	private GameObject descriptor;
	private GameObject stats;
	// Use this for initialization
	void Start () {
		obj = null;
		descriptor = null;
		stats = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Setup(GameObject shape) {
		obj = GameObject.Instantiate (shape, transform);
		obj.transform.localPosition = new Vector3 (0, 0, 0);
		obj.transform.localScale = new Vector3 (1f, 1f, 1f);
		string name = shape.GetComponent<MeshFilter> ().name;
		descriptor = GameObject.Instantiate(text, transform);
		descriptor.transform.localPosition = new Vector3(0f, 3f, 0f);
		descriptor.transform.localEulerAngles = new Vector3 (0f, 180f, 0f);
		descriptor.transform.localScale = new Vector3 (.05f, .05f, .05f);
		if(name.Contains("Cyl")){
			descriptor.GetComponent<AssignText>().Assign("Cylinder");
		}else if(name.Contains("Sphere")){
			descriptor.GetComponent<AssignText>().Assign ("Sphere");
		}else if(name.Contains("Cube")){
			descriptor.GetComponent<AssignText>().Assign ("Cube");
		}else if(name.Contains("Pyr")){
			descriptor.GetComponent<AssignText>().Assign ("Tetrahedron");
		}
		stats = GameObject.Instantiate(text, transform);
		stats.transform.localPosition = new Vector3(0f, 2f, 0f);
		stats.transform.localEulerAngles = new Vector3 (0f, 180f, 0f);
		stats.transform.localScale = new Vector3 (.05f, .05f, .05f);
		if (name.Contains ("Cyl")) {
			stats.GetComponent<AssignText> ().Assign ("Radius: " + obj.transform.localScale.x + "\nHeight: " + obj.transform.localScale.y);
		} else if (name.Contains ("Sphere")) {
			stats.GetComponent<AssignText> ().Assign ("Radius: " + obj.transform.localScale.x);
		}
		else if (name.Contains("Cube")){
			stats.GetComponent<AssignText> ().Assign ("Edge Length: " + obj.transform.localScale.x);
		}
		else if(name.Contains("Pyr")){
			stats.GetComponent<AssignText> ().Assign ("Edge Length: " + obj.transform.localScale.x);
		}
	}
}
