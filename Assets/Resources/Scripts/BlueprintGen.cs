using UnityEngine;
using System.Collections;

public class BlueprintGen : MonoBehaviour {
	public Texture2D blueprintData;
	public GameObject blueprintSquare;

	private GameObject[,] blueprint;

	void Start () {
		blueprint = new GameObject[blueprintData.width, blueprintData.height];

		for (int x = 0; x < blueprintData.width; x++) {
			for (int y = 0; y < blueprintData.height; y++) {
				if (Color.black == blueprintData.GetPixel(x, y)) {
					blueprint[x, y] = (GameObject) GameObject.Instantiate(blueprintSquare, new Vector2(x, y), Quaternion.identity);
					blueprint[x, y].transform.SetParent(transform);
				}
			}
		}
	}
}
