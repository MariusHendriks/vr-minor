using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereToCone : MonoBehaviour
{
    public float height = 2f;
    public float radius = 1f;
    public float xRotation = 8f;
    public float yRotation = 8f;
    private float x;
    private float y;
    private bool collided = false;
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> points = new List<Vector3>();
        points.Add(new Vector3(0, 0, 0));
        var steps = 30;

        List<int> triangles = new List<int>();

        for (int i = 0; i < steps; i++)
        {
            points.Add(new Vector3(Mathf.Cos(i * 2 * Mathf.PI / steps) * radius, 0, Mathf.Sin(i * 2 * Mathf.PI / steps) * radius));
        }

        points.Add(new Vector3(0, height, 0));

        for (int i = 0; i < steps; i++)
        {
            triangles.Add(0);
            triangles.Add(i + 1);
            if (i == steps - 1)
            {
                triangles.Add(1);
            }
            else
            {
                triangles.Add(i + 2);
            }
        }

        for (int i = 0; i < steps; i++)
        {
            triangles.Add(i + 1);
            triangles.Add(31);
            if (i == steps - 1)
            {
                triangles.Add(1);
            }
            else
            {
                triangles.Add(i + 2);
            }
        }

        Mesh mesh = new Mesh();
        mesh.vertices = points.ToArray();
        mesh.triangles = triangles.ToArray();

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        if (!collided)
        {
            x += xRotation * Time.deltaTime; // Needed to be done or else eulerangel would stop at 90 degrees
            y += yRotation * Time.deltaTime;
            transform.eulerAngles = new Vector3(x, y, 0);
        }


    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        collided = true;

    }
}