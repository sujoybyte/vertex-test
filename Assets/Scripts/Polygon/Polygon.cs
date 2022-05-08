using System.Collections.Generic;
using UnityEngine;

public class Polygon : Line
{
	private GameObject _polygon;
	private LineRenderer _polygonRenderer;

	public GameObject Object { get { return _polygon; } set { _polygon = value; } }


	public Polygon()
	{
		_polygon = new GameObject("polygon", typeof(LineRenderer));
		_polygonRenderer = _polygon.GetComponent<LineRenderer>();
	}

	internal void SetVertices(List<Vector3> vertices)
	{
		_polygonRenderer.positionCount = vertices.Count;
		_polygonRenderer.useWorldSpace = false;

		for (int i = 0; i < vertices.Count; i++)
		{
			_polygonRenderer.SetPosition(i, vertices[i]);
		}
	}
}
