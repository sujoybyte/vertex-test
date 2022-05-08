using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
	private Grid _gridLine;


	private void Start()
	{
		_gridLine = new Grid(transform);
		_gridLine.SetRenderer(_gridLine.GetLine, new Color(0f, 0f, 0f, 0.1f), 0.05f);

		SetGrid();
	}

	private void SetGrid()
	{
		for (int i = 0; i < 9; i++)
		{
			LineRenderer lineHorizontal = Instantiate(_gridLine.GetLine, transform).GetComponent<LineRenderer>();

			lineHorizontal.SetPosition(0, new Vector3(5, 4 - i, 0));
			lineHorizontal.SetPosition(1, new Vector3(-5, 4 - i, 0));
		}

		for (int i = 0; i < 9; i++)
		{
			LineRenderer lineVertical = Instantiate(_gridLine.GetLine, transform).GetComponent<LineRenderer>();

			lineVertical.SetPosition(0, new Vector3(4 - i, 5, 0));
			lineVertical.SetPosition(1, new Vector3(4 - i, -5, 0));
		}
	}
}
