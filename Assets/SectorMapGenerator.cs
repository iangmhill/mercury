﻿
using UnityEngine;
using System.Collections;

public class SectorMapGenerator : MonoBehaviour {
	
	public int xsize = 120;
	public int ysize = 80;
	public float planetsize = 10f;
	public int numberofplanets = 10;
	public GameObject sector_model;
	
	private float prob;
	private float xchange;
	private float ychange;	
	
	// Use this for initialization
	void Start () { 
		prob = (numberofplanets)/(xsize * ysize / (planetsize *planetsize * 4)); 
		for (float x = -xsize/2f; x<xsize/2f; x+=planetsize) {
			for (float y=-ysize/2f; y<ysize/2f; y+=planetsize) {
				if (Random.Range(0.0f,1.0f)<prob) {
					GameObject sector =  (GameObject)GameObject.Instantiate(sector_model,new Vector2(x,y),Quaternion.identity);
					sector.transform.localScale = new Vector3(planetsize,planetsize,planetsize);
					sector.transform.SetParent(transform);
				}
			}
		}
	}
}
