using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JianModelCtr : MonoBehaviour {

    public float _xzSpeed;//旋转速度

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.up * _xzSpeed * Time.deltaTime);


	}
}
