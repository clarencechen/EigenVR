using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShapes : MonoBehaviour {
	private SteamVR_LaserPointer lp;
	private float timer;
	private GameObject curr;

	public void OnEnter(object sender, PointerEventArgs e)
	{
		timer = Time.time;
		curr = e.target.gameObject;
	}
	public void OnExit(object sender, PointerEventArgs e)
	{
		timer = 0f;
		curr.GetComponent<Material> ().color = new Color (0f, 1f, .5f);
		curr = null;
	}
	// Use this for initialization
	void Start () {
		timer = 0f;
		curr = null;
		lp = Camera.main.gameObject.GetComponent<SteamVR_LaserPointer>();
		lp.PointerIn += OnEnter;
		lp.PointerOut += OnExit;
	}
	// Update is called once per frame
	void Update () {
		float now = Time.time;
		if (curr && now -timer > 5f) {
			if (curr.name.Equals ("LeftScroll")) {
				for (int i = 0; i < this.transform.childCount; i++) {
					Transform row = this.transform.GetChild (i).transform;
					for (int j = 0; j < row.childCount; j++) {
						Transform shape = row.GetChild (j).transform;
						if (shape.localPosition.x == 7.5) {
							shape.localPosition -= new Vector3 (15, 0, 0);
						} else {
							shape.localPosition += new Vector3 (5, 0, 0);
						}
					}
				}
			} else if (curr.name.Equals ("RightScroll")) {
				for (int i = 0; i < this.transform.childCount; i++) {
					Transform row = this.transform.GetChild (i).transform;
					for (int j = 0; j < row.childCount; j++) {
						Transform shape = row.GetChild (j).transform;
						if (shape.localPosition.x == -7.5) {
							shape.localPosition += new Vector3 (15, 0, 0);
						} else {
							shape.localPosition -= new Vector3 (5, 0, 0);
						}
					}
				}
			} else {
				for(int i = 1; i <= 3; i++)
				{
					GameObject info = this.transform.parent.GetChild (i).gameObject;
					if (info.transform.childCount == 0) {
						GameObject manip = GameObject.Instantiate (curr, info.transform);
						manip.transform.localPosition = new Vector3 (0, 0, 0);
						manip.transform.localScale = new Vector3 (.1f, .1f, .1f);
						break;
					}
				}
			}
			timer = 0f;
			curr.GetComponent<Material> ().color = new Color (0f, 1f, .5f);
			curr = null;
		}
		else if (curr) {
			curr.GetComponent<Material> ().color = new Color ((now -timer)/5f, 1f, .5f);
		}
	}
}
