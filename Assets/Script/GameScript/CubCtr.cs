using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubCtr : MonoBehaviour {



    public float _distance;

    public GameObject[,] _cubList = new GameObject[10, 10];

	// Use this for initialization
	void Start () {
        GameObject _cubpre = Resources.Load<GameObject>("Game/Cube");
        for (int i=0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                GameObject _cub = Instantiate(_cubpre);

                _cub.transform.position = new Vector3(j * _distance, 0, i * _distance);

                _cubList[i, j] = _cub;
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
