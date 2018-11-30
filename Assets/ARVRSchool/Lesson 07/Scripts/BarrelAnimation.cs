using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAnimation : MonoBehaviour
{

	public Shader shader;
	public Renderer barrelRender;
	private Material mat;
	void Start ()
	{
		mat = barrelRender.material;
	}
	
	// Update is called once per frame
	void Update ()
	{
		mat.shader = shader;
		mat.SetColor("_Color", Color.Lerp(Color.green, Color.red, Mathf.Sin(Time.time)));
		
	}

	private void OnDrawGizmos()
	{
		
	}
}
