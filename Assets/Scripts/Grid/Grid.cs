using UnityEngine;

public class Grid : Line
{
	private GameObject _gridLine;

	public GameObject GetLine { get { return _gridLine; } }


	public Grid(Transform parent)
	{
		_gridLine = new GameObject("grid_line", typeof(LineRenderer));
		_gridLine.transform.parent = parent;
	}
}
