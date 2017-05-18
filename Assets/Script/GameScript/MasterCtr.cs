using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MasterCtr : MonoBehaviour {

    private GPlayerInfo _playerInfo;

    public Camera mainCrma;

    private Transform CurrTransform;

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
        _playerInfo=GPlayerInfo.MasterInit();

        if (_playerInfo.NameID == ReceiveData.Instance.nameID)
        {
            string str = string.Format("玩家本人监听 NameID{0}", _playerInfo.NameID);
            Debug.Log(str);
            SfAddEvent.Instance.Add((int)ProtocalID.Move_Main, Move);
            SfAddEvent.Instance.Add((int)ProtocalID.Attack_Main, Attack);
           // SfAddEvent.Instance.Add((int)ProtocalID.CubInit_Main, CubInit);
        }
       

        Find();

    }

    void Find()
    {
       // _playerInfo.Cub = GameObject.Find("AllCub").GetComponent<CubCtr>();
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
                    if (0 <= _playerInfo.Hang && _playerInfo.Hang < 9)
                    {
                        transform.Translate(0, 0, _playerInfo.MoveDistance);
                        UpdateHL();
                    }
                    else
                    {
                        Debug.Log("向前移动超出范围");
                    }
                    
                    break;
                }   
            case (int)MoveType.Down:
                {
                    if (0 < _playerInfo.Hang && _playerInfo.Hang < 10)
                    {
                        transform.Translate(0, 0, -1 * _playerInfo.MoveDistance);
                        //_hang--;
                        UpdateHL();
                    }
                    else
                    {
                        Debug.Log("向后移动超出范围");
                    }
                    break;
                }        
            case (int)MoveType.Left:
                {
                    if (0 < _playerInfo.Lie && _playerInfo.Lie < 10)
                    {
                        transform.Translate(-1 * _playerInfo.MoveDistance, 0, 0);
                        UpdateHL();
                    }
                    else
                    {
                        Debug.Log("向左移动超出范围");
                    }
                   
                    break;
                }           
            case (int)MoveType.Right:
                {
                    if (0 <= _playerInfo.Lie && _playerInfo.Lie < 9)
                    {
                        transform.Translate(_playerInfo.MoveDistance, 0, 0);
                        UpdateHL();
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

        DianjiScreen();

    }

    /// <summary>
    /// 根据位置更新行列
    /// </summary>
    void UpdateHL()
    {

        _playerInfo.Hang = (int)transform.position.z / _playerInfo.MoveDistance;
        _playerInfo.Lie = (int)transform.position.x / _playerInfo.MoveDistance;
    }

    /// <summary>
    /// 点击屏幕
    /// </summary>
    void DianjiScreen(){
        if (Input.GetMouseButtonDown(0) && _playerInfo.NameID == ReceiveData.Instance.nameID)
        {
            Ray ray = mainCrma.ScreenPointToRay(Input.mousePosition);
            //Ray ray = new Ray(transform.position, -transform.up);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // 如果射线与平面碰撞，打印碰撞物体信息  
                Debug.Log("碰撞对象: " + hit.collider.gameObject.tag + "," + hit.collider.name);


                // 在场景视图中绘制射线  
                //Debug.DrawLine(ray.origin, hit.point, Color.red);

                if (hit.collider.gameObject.tag == "CanChoose")
                {
                    GameObject fazhangpre = Resources.Load<GameObject>("Model/Fazhang/fazhang");
                    GameObject fazhang = Instantiate(fazhangpre);
                    Vector3 weizhi = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y + 1f, hit.collider.transform.position.z);
                    fazhang.transform.position = weizhi;
                    //transform.position= weizhi;
                    //UpdateHL();

                    //SfAddEvent.Instance.Trigger((int)ProtocalID.CubInit_Main);

                    string str = string.Format("移动到攻击位置:{0},行:{1},列{2}", weizhi, _playerInfo.Hang, _playerInfo.Lie);

                    Debug.Log(str);
                }
            }

        }
    }

    /// <summary>
    /// 攻击范围
    /// </summary>
    /// <param name="ob"></param>
     void Attack(object ob)
    {

        GameControl.Instance.Cub.AttackBianSe(_playerInfo.Hang + 1, _playerInfo.Lie + 0);
        GameControl.Instance.Cub.AttackBianSe(_playerInfo.Hang - 1, _playerInfo.Lie + 0);
        GameControl.Instance.Cub.AttackBianSe(_playerInfo.Hang + 0, _playerInfo.Lie + 1);
        GameControl.Instance.Cub.AttackBianSe(_playerInfo.Hang + 0, _playerInfo.Lie + 1);
        GameControl.Instance.Cub.AttackBianSe(_playerInfo.Hang - 1, _playerInfo.Lie + 1);
        GameControl.Instance.Cub.AttackBianSe(_playerInfo.Hang - 1, _playerInfo.Lie - 1);
        GameControl.Instance.Cub.AttackBianSe(_playerInfo.Hang + 1, _playerInfo.Lie + 1);
        GameControl.Instance.Cub.AttackBianSe(_playerInfo.Hang + 1, _playerInfo.Lie - 1);

    }

    //void AttackBianSe(int i,int j)
    //{
    //    if (_playerInfo.Hang + i>=0 && _playerInfo.Hang + i <= 9 && _playerInfo.Lie + j >= 0 && _playerInfo.Lie + j <= 9)
    //    { 
    //        GameObject obj = _playerInfo.Cub._cubList[_playerInfo.Hang + i, _playerInfo.Lie + j];
    //        obj.GetComponent<Renderer>().material.color = Color.red;
    //        obj.tag = "CanChoose";
    //        _canCubList.Add(obj);
    //    }
       

    //}

    //void CubInit(object ob)
    //{
    //    for(int i=0;i< _canCubList.Count; i++)
    //    {
    //        GameObject obj = _canCubList[i];
    //        obj.GetComponent<Renderer>().material.color = Color.white;
    //        obj.tag = "Untagged";
    //    }
    //}

}
