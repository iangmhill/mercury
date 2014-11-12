using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SectorMapGenerator : MonoBehaviour {
	
	public int xsize = 120;
	public int ysize = 80;
	public float planetsize = 10f;
	public int numberofplanets = 10;
	public float planetpercenterror=10;
	public GameObject sector_model;
	
	private float prob;
	private float xchange;
	private float ychange;
	private int destroyedplanet;
	private bool goodsector=false;
	private GameObject testingplanet;
	private List<GameObject> locations= new List<GameObject>();

	
	
	// Use this for initialization
	void Start () { 
		while (!goodsector){
			for (int i = 0;i<locations.Count; i++){
				Destroy (locations[i] as GameObject);
				print ("Planet Destroyed");
			}
			locations = new List<GameObject>();
			prob = (numberofplanets-locations.Count)/(xsize * ysize / (planetsize *planetsize * 4)); 
			for (float x = -xsize/2f; x<xsize/2f; x+=planetsize*2) {
				for (float y=-ysize/2f; y<ysize/2f; y+=planetsize*2) {
					if (Random.Range(0.0f,1.0f)<prob) {
							xchange = Random.Range (-planetsize/2f, planetsize/2f);
							ychange = Random.Range (-planetsize/2f, planetsize/2f);
							GameObject sector =  (GameObject)GameObject.Instantiate(sector_model,new Vector2(x+xchange,y+ychange),Quaternion.identity);
							sector.transform.localScale = new Vector3(planetsize,planetsize,planetsize);
							sector.transform.SetParent(transform);
							locations.Add(sector);
					}

				}
			}
			print (locations.Count + "planets created");
			if (locations.Count>=numberofplanets*(1-planetpercenterror/100)){
				goodsector = true;
			}
		}
		while (locations.Count > numberofplanets*(1+planetpercenterror/100)) {
					destroyedplanet = Random.Range (0,locations.Count-1);
					Destroy (locations[destroyedplanet] as GameObject);
					locations.RemoveAt(destroyedplanet);
		}
		print(Time.realtimeSinceStartup);
	}
}