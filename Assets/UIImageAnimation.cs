﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIImageAnimation : MonoBehaviour {

	public Sprite[] sprites;
	public int spritePerFrame = 6;
	public bool loop = true;
	public bool destroyOnEnd = false;

	public int index = 0;
	public Image image;
	public int frame = 0;

	void Awake() {
		image = GetComponent<Image> ();
	}

	void Update () {
		image = GetComponent<Image>();

		if (!loop && index == sprites.Length) return;
		frame ++;
		if (frame < spritePerFrame) return;
		image.sprite = sprites [index];
		frame = 0;
		index ++;
		if (index >= sprites.Length) {
			if (loop) index = 0;
			if (destroyOnEnd) Destroy (gameObject);
		}
	}
}