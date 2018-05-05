using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathCreator))]
public class PathEditor : Editor {

	PathCreator creator;

	void OnSceneGUI()
	{
		Draw();
	}

	void Draw()
	{
		Handles.FreeMoveHandle(Vector3.zero, Quaternion.identity, 0.1f, Vector2.zero, Handles.CylinderHandleCap);
	}
	
	void OnEnable()
	{
		creator = (PathCreator)target;
	}
}
