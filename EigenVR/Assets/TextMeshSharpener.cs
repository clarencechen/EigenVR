using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshSharpener : MonoBehaviour {
	private float lastPixelHeight = -1;
    private TextMesh textMesh;
    void Start() {
        textMesh = GetComponent<TextMesh>();
        resize();
    }

    void Update() {
        // Always resize in the editor, or when playing the game, only when the resolution changes
        if (Camera.main.pixelHeight != lastPixelHeight || (Application.isEditor && !Application.isPlaying)) resize();
    }

    private void resize() {
        float ph = Camera.main.pixelHeight;
        float ch = Camera.main.orthographicSize;
        float pixelRatio = (ch * 2.0f) / ph;
        float targetRes = 128f;
        textMesh.characterSize = pixelRatio * Camera.main.orthographicSize / Mathf.Max(transform.localScale.x, transform.localScale.y);
        textMesh.fontSize = (int)Mathf.Round(targetRes / textMesh.characterSize);
        lastPixelHeight = ph;
    }
}
