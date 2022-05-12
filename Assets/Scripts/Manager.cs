using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Manager : MonoBehaviour
{
	private Camera _camera;
	private GameObject _shapeParent;
	private List<Shape> _shapes;
	private Shape _currentShape;
	private Shape _newShape;

	private float _shapePositionZ = 0f;
	private bool _isShapeCompleted = false;
	private bool _isShapeCopied = false;
	private bool _isShapeReset = false;


	private void Start()
	{
		_camera = Camera.main;

		_shapes = new List<Shape>();
		_shapes.Add(new Shape());
		_currentShape = _shapes[0];

		_shapeParent = new GameObject("shape");
		_currentShape.Polygon.Object.transform.parent = _shapeParent.transform;
	}

	private void Update()
	{
		bool isMouseNotOverUI = !EventSystem.current.IsPointerOverGameObject();

		if (Input.GetMouseButtonDown(0) && isMouseNotOverUI)
		{
			if (_isShapeCompleted || _isShapeReset)
			{
				CreateShape();

				_isShapeCompleted = false;
				_isShapeReset = false;
			}

			if (_isShapeCopied)
			{
				_isShapeCopied = false;
				return;
			}

			Vector3 worldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
			worldPosition = new Vector3(worldPosition.x, worldPosition.y, -0.1f);

			_currentShape.Vertices.Add(worldPosition);

			if (_currentShape.Vertices.Count > 1)
			{
				SetShape(_currentShape, _currentShape.Vertices);
			}
		}

		if (isMouseNotOverUI && _isShapeCopied)
		{
			Vector3 worldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
			worldPosition = new Vector3(worldPosition.x, worldPosition.y,
				_newShape.Polygon.Object.transform.position.z);

			_newShape.Polygon.Object.transform.position = worldPosition;
		}
	}

	public void Complete()
	{
		if (_currentShape.Vertices.Count == 0 || _shapeParent.transform.childCount == 0) return;

		SetShape(_currentShape, _currentShape.Vertices, true);
		_currentShape.Polygon.SetColor(Color.black);

		_isShapeCompleted = true;
	}

	public void Copy()
	{
		if (!_isShapeCompleted || _isShapeReset) return;

		CreateShape(false);
		SetShape(_newShape, _currentShape.Vertices);
		_newShape.Polygon.SetColor(Color.black);

		_isShapeCopied = true;
	}

	public void Reset()
	{
		_shapes.Clear();

		for (int i = 0; i < _shapeParent.transform.childCount; i++)
		{
			Destroy(_shapeParent.transform.GetChild(i).gameObject);
		}

		_shapePositionZ = 0f;
		_isShapeReset = true;
	}

	private void CreateShape(bool isCurrentNew = true)
	{
		_shapePositionZ -= 0.1f;

		_newShape = new Shape();
		_newShape.Polygon.Object.transform.parent = _shapeParent.transform;
		_newShape.Polygon.Object.transform.position += new Vector3(0f, 0f, _shapePositionZ);
		_currentShape = isCurrentNew ? _newShape : _currentShape;

		_shapes.Add(_newShape);
	}
	private void SetShape(Shape shape, List<Vector3> vertices, bool closeShape = false)
	{
		if (closeShape) shape.Vertices.Add(vertices[0]);

		shape.Polygon.SetVertices(vertices);
		shape.Triangles.SetTriangles(vertices);
	}
}
