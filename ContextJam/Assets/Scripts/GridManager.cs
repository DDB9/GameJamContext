using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private float spacing = 5f;

    public float Size { get { return spacing; } }

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / spacing);
        int yCount = Mathf.RoundToInt(position.y / spacing);
        int zCount = Mathf.RoundToInt(position.z / spacing);

        Vector3 result = new Vector3(
            (float)xCount * spacing,
            (float)yCount * spacing,
            (float)zCount * spacing);

        result += transform.position;

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (float x = 0; x < 5; x += spacing)
        {
            for (float z = 0; z < 5; z += spacing)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }
}
