using UnityEngine;
using System.Collections;

public class cubeController : MonoBehaviour 
{

	// Use this for initialization
	
	void changeColor()
	{
		Color select = new Color (191, 87, 0);
		Color deSelect = new Color (0, 0, 0);
		MeshRenderer gameObjectRenderer = gameObject.GetComponent<MeshRenderer> ();
		Material newMaterial1 = new Material (Shader.Find ("Transparent/Diffuse"));
		Material newMaterial2 = new Material (Shader.Find ("Transparent/Diffuse"));
		newMaterial1.color = select;
		newMaterial2.color = deSelect;

		if (colorChanger) 
		{
			gameObjectRenderer.material = newMaterial1;
			colorChanger = false;
		}
		else
		{
			gameObjectRenderer.material = newMaterial2;
			colorChanger = true;
		}


	}
	void OnMouseDown()
	{
		changeColor ();
	}
		


}
