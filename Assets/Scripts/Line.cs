
using UnityEngine;

public class Line
{
	private LineRenderer _lineRenderer;
	private Material _material;


	internal void SetRenderer(GameObject line, Color color, float lineWidth)
	{
		_material = new Material(Shader.Find("Sprites/Default"));
		_lineRenderer = line.GetComponent<LineRenderer>();

		_lineRenderer.startWidth = _lineRenderer.endWidth = lineWidth;
		_lineRenderer.startColor = _lineRenderer.endColor = color;
		_lineRenderer.material = _material;
	}

	internal void SetColor(Color color)
	{
		_lineRenderer.startColor = _lineRenderer.endColor = color;
	}
}