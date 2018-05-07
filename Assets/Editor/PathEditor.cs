using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathCreator))]
public class PathEditor : Editor {

	PathCreator creator;
	Path path;
	private Vector3 pos = Vector3.zero; 
	private Texture2D aaTex;

	void OnSceneGUI()
	{
		Draw();
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

	}

	void Draw()
	{
		for (int i = 0; i < path.numSegments; i++)
		{
			Vector3[] points = path.GetPointsInSegment(i);
			Handles.DrawBezier(points[0], points[3], points[1], points[2], Color.white, aaTex, 2.5f);

			Handles.color = Color.gray;
			Handles.DrawDottedLine(points[1],points[0], 3);
			Handles.DrawDottedLine(points[2],points[3], 3);
		}

		Handles.color = Color.black;
		for (int i = 0; i < path.numPoints; i++)
		{
			Vector3 newPos = Handles.FreeMoveHandle(path[i], Quaternion.identity, 0.1f, Vector3.zero, Handles.SphereHandleCap);

			if (path[i] != newPos)
			{
				Undo.RecordObject(creator, "Move point");
				path.MovePoint(i, newPos);
			}
		}
		
	}
	
	void OnEnable()
	{
		aaTex = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/EditorTextures/line.png", typeof(Texture2D));
		creator = (PathCreator)target;
		if (creator.path == null) creator.CreatePath();
		path = creator.path;
	}
}
