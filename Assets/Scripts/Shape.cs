using System.Collections.Generic;
using UnityEngine;

public class Shape
{
	private Polygon _polygon;
	private Triangles _triangles;
	private List<Vector3> _vertices = new List<Vector3>();

	public Polygon Polygon { get { return _polygon; } set { _polygon = value; } }
	public Triangles Triangles { get { return _triangles; } set { _triangles = value; } }
	public List<Vector3> Vertices { get { return _vertices; } set { _vertices = value; } }


	public Shape()
	{
		_polygon = new Polygon();
		_polygon.SetRenderer(_polygon.Object, Color.green, 0.1f);
		_triangles = new Triangles(_polygon.Object.transform);
	}
}
