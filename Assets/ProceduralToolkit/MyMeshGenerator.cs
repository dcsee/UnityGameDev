using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMeshGenerator : MonoBehaviour {

    // Use this for initialization
    void Start () {

        makeTetrahedron();

/*        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;*/
    }

    void makeTetrahedron()
    {
        //make and spawn a tetrahedron
        GameObject g = new GameObject();
        g.transform.position = new Vector3(10, 10, 10);
        Mesh t = ProceduralToolkit.MeshE.Tetrahedron(40);
        g.AddComponent<MeshFilter>().mesh = t;
    }	

}
