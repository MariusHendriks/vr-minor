using UnityEngine;

public class SphereToCube : MonoBehaviour
{
    public float xRotation = 8f;
    public float yRotation = 8f;
    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] verticles =
        {
            new Vector3(-0.5f ,-0.5f, 0.5f), //0
            new Vector3(-0.5f ,0.5f, 0.5f), //1
            new Vector3(0.5f ,-0.5f, 0.5f), //2
            new Vector3(0.5f ,0.5f, 0.5f), //3
            new Vector3(-0.5f ,-0.5f, -0.5f), //4
            new Vector3(-0.5f ,0.5f, -0.5f), //5
            new Vector3(0.5f ,-0.5f, -0.5f), //6
            new Vector3(0.5f ,0.5f, -0.5f), //7
        };
        int[] triangles = { 1, 0, 2, 1, 2, 3, 0, 5, 4, 0, 1, 5, 0, 4, 2, 4, 6, 2, 1, 3, 5, 5, 3, 7, 4, 7, 6, 4, 5, 7, 7, 3, 6, 6, 3, 2 };

        Mesh mesh = new Mesh();

        mesh.vertices = verticles;
        mesh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        x += xRotation * Time.deltaTime; // Needed to be done or else eulerangel would stop at 90 degrees
        y += yRotation * Time.deltaTime;
        transform.eulerAngles = new Vector3(x, y, 0);
    }
}

