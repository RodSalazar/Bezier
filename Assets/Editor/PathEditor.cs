using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathCreator))]
public class PathEditor : Editor {

	PathCreator creator;
	Path path;
	private Vector3 pos = Vector3.zero; 
	public Texture image = Resources.Load("test.png") as Texture;

	void OnSceneGUI()
	{
		Handles.Label(pos,image);
		Draw();
	}

	void Draw()
	{
		Handles.color = Color.red;
		for (int i = 0; i < path.numPoints; i++)
		{
			Vector3 newPos = Handles.FreeMoveHandle(path[i], Quaternion.identity, 0.1f, Vector3.zero, Handles.DotHandleCap);
			if (path[i] != newPos)
			{
				Undo.RecordObject(creator, "Move point");
				path.MovePoint(i, newPos);
			}
		}
		
	}
	
	void OnEnable()
	{
		creator = (PathCreator)target;
		if (creator.path == null) creator.CreatePath();
		path = creator.path;
	}
}
