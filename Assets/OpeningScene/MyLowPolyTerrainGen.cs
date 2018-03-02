using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProceduralToolkit.Examples;
using ProceduralToolkit;

public class MyLowPolyTerrainGen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.AddComponent(typeof(MeshFilter));
        Gradient terrainColor = makeGradient();
        GetComponent<MeshFilter>().mesh = LowPolyTerrainGenerator.TerrainDraft(
            new Vector3(200, 200, 20), 5.0f, 10.0f, terrainColor).ToMesh();

	}

    private Gradient makeGradient()
    {
        Gradient g = new Gradient();
        GradientColorKey[] gck;
        GradientAlphaKey[] gak;
        g = new Gradient();
        gck = new GradientColorKey[2];
        gck[0].color = Color.red;
        gck[0].time = 0.0F;
        gck[1].color = Color.blue;
        gck[1].time = 1.0F;
        gak = new GradientAlphaKey[2];
        gak[0].alpha = 1.0F;
        gak[0].time = 0.0F;
        gak[1].alpha = 0.0F;
        gak[1].time = 1.0F;
        g.SetKeys(gck, gak);
        Debug.Log(g.Evaluate(0.25F));
        return g;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
