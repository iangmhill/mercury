using UnityEngine;
using System.Collections;

public class SectorMapGenerator : MonoBehaviour {
	
	public int xsize = 120;
	public int ysize = 80;
	public GameObject sector_model;
	
	private float prob= 0.01f;
	private float xchange;
	private float ychange;	
	
	// Use this for initialization
	void Start () { 
		for (int x = -xsize/2; x<xsize/2; x++) {
			for (int y=-ysize/2; y<ysize/2; y++) {
				if (Random.Range(0.0f,1.0f)<prob) {
					GameObject sector =  (GameObject)GameObject.Instantiate(sector_model,new Vector2(x,y),Quaternion.identity);
					sector.transform.SetParent(transform);
				}
			}
		}
	}
}