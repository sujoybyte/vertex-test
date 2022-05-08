using System.Collections.Generic;
using UnityEngine;

public class Triangles
{
    private GameObject _triangles;
    private Mesh _trianglesMesh;
    private MeshFilter _trianglesMeshFilter;
    private MeshRenderer _trianglesMeshRenderer;
    private Material _trianglesMaterial;

    public GameObject Object { get { return _triangles; } set { _triangles = value; } }


    public Triangles(Transform parent)
    {
        _triangles = new GameObject("triangles", typeof(MeshFilter), typeof(MeshRenderer));
        _triangles.transform.parent = parent;
        _trianglesMeshFilter = _triangles.GetComponent<MeshFilter>();
        _trianglesMeshRenderer = _triangles.GetComponent<MeshRenderer>();

        _trianglesMesh = new Mesh();
        _trianglesMeshFilter.mesh = _trianglesMesh;
        _trianglesMaterial = new Material(Shader.Find("Sprites/Default"));
    }

    internal void SetTriangles(List<Vector3> verticesPositions)
	{
        int verticesCount = verticesPositions.Count;

        Vector3[] verteicesPositionsArray = new Vector3[verticesCount];
        int[] trianglesVerticesArray = new int[3 * (verticesCount - 2)];

        for (int i = 0; i < verticesCount; i++)
		{
            verteicesPositionsArray[i] = 
                new Vector3(verticesPositions[i].x, verticesPositions[i].y, verticesPositions[i].z);
		}

        for (int i = 0; i < verticesCount - 2; i++)
        {
            trianglesVerticesArray[3 * i] = 0;
            trianglesVerticesArray[(3 * i) + 1] = i + 1;
            trianglesVerticesArray[(3 * i) + 2] = i + 2;
        }

        FillTriangles(verteicesPositionsArray, trianglesVerticesArray);
    }

    private void FillTriangles(Vector3[] vertices, int[] triangles)
	{
        _trianglesMesh.vertices = vertices;
        _trianglesMesh.triangles = triangles;
        _trianglesMaterial.color = new Color(0.9f, 0.0f, 0.4f, 1.0f);
        _trianglesMeshRenderer.material = _trianglesMaterial;
    }
}
