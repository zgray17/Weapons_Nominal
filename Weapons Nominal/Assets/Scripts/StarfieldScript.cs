using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:Zak Gray
public class StarfieldScript : MonoBehaviour {
    public float paralax = 50000;
	// Update is called once per frame
	void Update () {

        Material mat = GetComponent<MeshRenderer>().material;//get material

        Vector2 offset = new Vector2(offset.x = transform.position.x / paralax, offset.y = transform.position.y / paralax);//set offset as you move

        mat.SetTextureOffset("_MainTex", offset);//set offset to material

	}
}
