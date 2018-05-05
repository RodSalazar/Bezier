using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Path {

	[SerializeField]
	List<Vector3> points;

	public Path(Vector3 center)
	{
		points = new List<Vector3>
		{
			center + Vector3.left,
			center + (Vector3.left + Vector3.up) * 0.5f,
			center + (Vector3.right + Vector3.down) * 0.5f,
			center + Vector3.right
		};
	}

	public void AddSegment(Vector3 anchorPosition)
	{
		points.Add(points[points.Count - 1] * 2 - points[points.Count - 2]);
		points.Add((points[points.Count - 1] + anchorPosition) * 0.5f);
		points.Add(anchorPosition);
	}

	public Vector3[] GetPointsInSegment(int i)
	{
		return new Vector3[]{ points[i * 3], }
	}
}
