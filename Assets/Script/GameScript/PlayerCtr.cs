using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour {


    public int _hang=0;

    public int _lie=0;

    private CubCtr _cub;

    public float _moveDistance;

    public int NameID;

    List<GameObject> _canCubList=new List<GameObject>();



    enum MoveType
    {

        Up,       //向上
        Down,      //向下
        Left,     //向左
        Right    //向右
      
    }

    private void Awake()
    {

        if (NameID == ReceiveData.Instance.nameID)
        {
            string str = string.Format("玩家本人监听 NameID{0}", NameID);
            Debug.Log(str);
            SfAddEvent.Instance.Add((int)ProtocalID.Move_Main, Move);
            SfAddEvent.Instance.Add((int)ProtocalID.Move_Attack, Attack);
            SfAddEvent.Instance.Add((int)ProtocalID.Move_CubInit, CubInit);
        }
       

        Find();

    }

    void Find()
    {
        _cub = GameObject.Find("AllCub").GetComponent<CubCtr>();
    }

    // Use this for initialization
    void Start () {

        
		
	}

    void Move(object ob)
    {

        switch ((int)ob)
        {
            case (int)MoveType.Up:
                {
                    if (0 <= _hang && _hang < 9)
                    {
                        transform.Translate(0, 0, _moveDistance);
                        _hang++;
                    }
                    else
                    {
                        Debug.Log("向前移动超出范围");
                    }
                    
                    break;
                }   
            case (int)MoveType.Down:
                {
                    if (0 < _hang && _hang < 10)
                    {
                        transform.Translate(0, 0, -1 * _moveDistance);
                        _hang--;
                    }
                    else
                    {
                        Debug.Log("向后移动超出范围");
                    }
                    break;
                }        
            case (int)MoveType.Left:
                {
                    if (0 < _lie && _lie < 10)
                    {
                        transform.Translate(-1 * _moveDistance, 0, 0);
                        _lie--;
                    }
                    else
                    {
                        Debug.Log("向左移动超出范围");
                    }
                   
                    break;
                }           
            case (int)MoveType.Right:
                {
                    if (0 <= _lie && _lie < 9)
                    {
                        transform.Translate(_moveDistance, 0, 0);
                        _lie++;
                    }
                    else
                    {
                        Debug.Log("向右移动超出范围");
                    }
                    //transform.Rotate(0, 90, 0);
                    break;
                }
                
        }


    }
	
	// Update is called once per frame
	 void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, -transform.up);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // 如果射线与平面碰撞，打印碰撞物体信息  
                Debug.Log("碰撞对象: " + hit.collider.gameObject.tag+","+ hit.collider.name);
                // 在场景视图中绘制射线  
                //Debug.DrawLine(ray.origin, hit.point, Color.red);
            }

        }

    }



     void Attack(object ob)
    {


        BianSe(1, 0);
        BianSe(-1, 0);
        BianSe(0, 1);
        BianSe(0, -1);  
             
    }

    void BianSe(int i,int j)
    {
        if ( _hang + i>=0 && _hang + i <= 9 && _lie + j >= 0 && _lie + j <= 9)
        { 
            GameObject obj = _cub._cubList[_hang + i, _lie+j];
            obj.GetComponent<Renderer>().material.color = Color.red;
            obj.tag = "CanChoose";
            _canCubList.Add(obj);
        }
       

    }

    void CubInit(object ob)
    {
        for(int i=0;i< _canCubList.Count; i++)
        {
            GameObject obj = _canCubList[i];
            obj.GetComponent<Renderer>().material.color = Color.white;
            obj.tag = "Untagged";
        }
    }

}
