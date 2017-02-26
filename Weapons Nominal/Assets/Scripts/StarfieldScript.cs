using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfieldScript : MonoBehaviour {
    public float paralax = 50000;
	// Update is called once per frame
	void Update () {

        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.GetTextureOffset("_MainTex");

        offset.x = transform.position.x / paralax;

        offset.y = transform.position.y / paralax;

        mat.SetTextureOffset("_MainTex", offset);

	}
}
