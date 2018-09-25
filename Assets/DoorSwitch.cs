using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour {

    public Transform thisO;
    public Transform finalPosition;
    Quaternion rot;
    public float speed;
    bool pressed = false;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (pressed)
        {
            thisO.position = Vector3.MoveTowards(thisO.position, finalPosition.position, Time.deltaTime * speed);
            thisO.rotation = Quaternion.RotateTowards(thisO.rotation, finalPosition.rotation, Time.deltaTime * 18 * speed);
        }

     
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pressed = true;
        }
    }
}
