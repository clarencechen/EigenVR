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
		if (!IsScroll (curr)) {
			curr.GetComponent<Renderer> ().material.color = new Color (0f, 1f, .5f);
		}
		curr = null;
	}
	private bool IsScroll(GameObject obj)
	{
		return obj.name.Contains ("Scroll");
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
			if (IsScroll(curr)) {
				Transform menu = this.transform.GetChild (0);
				for (int i = 0; i < menu.transform.childCount; i++) {
					Transform row = menu.transform.GetChild (i).transform;
					bool left = curr.name.Contains("Left");
					for (int j = 0; j < row.childCount; j++) {
						Transform shape = row.GetChild (j).transform;
						if (shape.localPosition.x == (left ? 7.5 : -7.5)) {
							shape.localPosition += left ? new Vector3 (-15, 0, 0) : new Vector3 (15, 0, 0);
						} else {
							shape.localPosition += left ? new Vector3 (5, 0, 0) : new Vector3(-5, 0, 0);
						}
					}
				}
			} else {
				curr.GetComponent<MeshRenderer> ().material.color = new Color (0f, 1f, .5f);
				for(int i = 1; i <= 3; i++)
				{
					GameObject info = this.transform.parent.GetChild (i).gameObject;
					if (info.transform.childCount == 0) {
						GameObject manip = GameObject.Instantiate (curr, info.transform);
						manip.transform.localPosition = new Vector3 (0, 0, 0);
						manip.transform.localScale = new Vector3 (1f, 1f, 1f);
						break;
					}
				}
				curr = null;
				timer = 0f;
			}
			timer = Time.time;
		}
		else if (curr && !IsScroll(curr)) {
			curr.GetComponent<MeshRenderer> ().material.color = new Color ((now -timer)/5f, 1f, .5f);
		}
	}
}