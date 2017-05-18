using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubCtr : MonoBehaviour {



    public float _distance;

    public GameObject[,] _cubList = new GameObject[10, 10];


    private List<GameObject> _canCubList = new List<GameObject>();


    private void Awake()
    {
        GameControl.Instance.Cub = this;
    }
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

    /// <summary>
    /// 显示攻击范围
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
   public void AttackBianSe(int i, int j)
    {
        if ( i >= 0 && i <= 9 &&  j >= 0 &&  j <= 9)
        {
            GameObject obj = _cubList[i,j];
            obj.GetComponent<Renderer>().material.color = Color.red;
            obj.tag = "CanChoose";
            _canCubList.Add(obj);
        }


    }
    /// <summary>
    /// 初始化方块
    /// </summary>
    /// <param name="ob"></param>
    public void CubInit()
    {
        for (int i = 0; i < _canCubList.Count; i++)
        {
            GameObject obj = _canCubList[i];
            obj.GetComponent<Renderer>().material.color = Color.white;
            obj.tag = "Untagged";
        }
    }




}
