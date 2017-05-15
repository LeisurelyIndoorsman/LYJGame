using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0.1f*Time.deltaTime, 0, 0);
        if (transform.position.x <= -12.4f)
        {
            transform.position = new Vector3(12.4f, transform.position.y, transform.position.z);
        }
	}
}
