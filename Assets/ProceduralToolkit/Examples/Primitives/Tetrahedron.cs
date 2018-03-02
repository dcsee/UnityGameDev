using UnityEngine;

namespace ProceduralToolkit.Examples.Primitives
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class Tetrahedron : MonoBehaviour
    {
        public float radius = 1f;

        private void Start()
        {
            GetComponent<MeshFilter>().mesh = MeshE.Tetrahedron(radius);
//            MeshFilter m = GetComponent<MeshFilter>();
//            m.mesh = MeshE.Tetrahedron(radius);
        }
    }
}