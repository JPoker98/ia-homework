using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {


    public float radiusCollision;
    public Material collisionMaterial;
    //Collider bounds;

    // Use this for initialization
    void Start() {
        
        if (GetComponent<SphereCollider>() != null)
        {

            GetComponent<SphereCollider>().radius = radiusCollision;
        }

        if (GetComponent<BoxCollider>() != null)
        {


        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        GetComponent<MeshRenderer>().material = collisionMaterial;
    }
}
