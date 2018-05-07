using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour {

	[HideInInspector]
	public Path path;
	
	public List<Vector3> points;
	
	public void CreatePath()
	{
		path = new Path(transform.position);
		
	}
}
