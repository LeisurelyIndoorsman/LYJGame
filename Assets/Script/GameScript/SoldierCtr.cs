using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoldierCtr : MonoBehaviour {

    public GPlayerInfo _playerInfo;

    public Camera mainCrma;

    private Vector3 CurrTransform;

    private List<GameObject> _jiantou= new List<GameObject>();

    private List<GameObject> _attack = new List<GameObject>();

    private List<GameObject> _canCubList=new List<GameObject>();

    private List<OverSend> _gameData = new List<OverSend>();


    int _ani = 0;

    bool _Isanimation = false;

    public int _remainStep;


    enum MoveType
    {

        Up,       //向上
        Down,      //向下
        Left,     //向左
        Right    //向右
      
    }


    private void Awake()
    {
        _playerInfo=GPlayerInfo.SoldierInit();
        _remainStep = _playerInfo.MaxStepNum - _playerInfo.StepNum;

        AddEvent();
        Find();

    }

    void Find()
    {
       
    }

    void AddEvent()
    {
        if (_playerInfo.NameID == ReceiveData.Instance.nameID)
        {
            string str = string.Format("玩家本人监听 NameID{0}", _playerInfo.NameID);
            Debug.Log(str);
            SfAddEvent.Instance.Add((int)ProtocalID.HuiHeStar_Main, HuiHeStar);//回合开始
            SfAddEvent.Instance.Add((int)ProtocalID.Move_Main, Move);//移动
            SfAddEvent.Instance.Add((int)ProtocalID.Attack_Main, Attack);//攻击
            //SfAddEvent.Instance.Add((int)ProtocalID.CubInit_Main, CubInit);//清除Cub颜色
            SfAddEvent.Instance.Add((int)ProtocalID.AllRevocation_Main,AllRevocation);//全部撤销
            SfAddEvent.Instance.Add((int)ProtocalID.HuiHeOver_Main, HuiHeOver);//回合结束 


            
        }
    }

    // Use this for initialization
    void Start () {
       


    }

    void Move(object ob)
    {
        if (_playerInfo.StepNum < _playerInfo.MaxStepNum)
        {
            switch ((int)ob)
            {
                case (int)MoveType.Up:
                    {
                        if (0 <= _playerInfo.Hang && _playerInfo.Hang < 9)
                        {
                            CreatePath(0);
                            transform.Translate(0, 0, _playerInfo.MoveDistance);
                            UpdateHL(0);
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
                            CreatePath(180);
                            transform.Translate(0, 0, -1 * _playerInfo.MoveDistance);
                            //_hang--;
                            UpdateHL(0);
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
                            CreatePath(-90);
                            transform.Translate(-1 * _playerInfo.MoveDistance, 0, 0);
                            UpdateHL(0);
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
                            CreatePath(90);
                            transform.Translate(_playerInfo.MoveDistance, 0, 0);
                            UpdateHL(0);
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
       


    }
	
	// Update is called once per frame
	 void Update () {

        DianjiScreen();

    }




    /// <summary>
    /// 点击屏幕
    /// </summary>
    void DianjiScreen()
    {
        if (Input.GetMouseButtonDown(0) && _playerInfo.NameID == ReceiveData.Instance.nameID&&_playerInfo.StepNum<_playerInfo.MaxStepNum)
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

                    GameObject jianpre = Resources.Load<GameObject>("Model/Jian/Attack");

                    GameObject jian = Instantiate(jianpre);

                    _attack.Add(jian);

                    Vector3 weizhi = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y + 1f, hit.collider.transform.position.z);

                    jian.transform.position = weizhi;

                    transform.position= weizhi;

                    UpdateHL(1);

                    GameControl.Instance.Cub.CubInit();

                    string str = string.Format("移动到攻击位置:{0},行:{1},列{2}", weizhi, _playerInfo.Hang, _playerInfo.Lie);

                    Debug.Log(str);

                    UICtr.Instance.BackClick();



                }
            }

        }
    }


    /// <summary>
    /// 根据位置更新行列
    /// </summary>
    void UpdateHL(int i)
    {

        OverSend _moveData = new OverSend();

        _moveData.byType = i;

        _playerInfo.Hang = (int)transform.position.z / _playerInfo.MoveDistance;

        _playerInfo.Lie = (int)transform.position.x / _playerInfo.MoveDistance;

        _moveData.byHang = _playerInfo.Hang;

        _moveData.byLie = _playerInfo.Lie;

        _gameData.Add(_moveData);

        _playerInfo.StepNum++;

        _remainStep = _playerInfo.MaxStepNum - _playerInfo.StepNum;


    }




    /// <summary>
    /// 生成路径箭头
    /// </summary>
    /// <param name="angle"></param>
    void CreatePath(float angle)
    {

        GameObject _arrowsobj = Resources.Load<GameObject>("Model/Jiantou/Jiantou");

        GameObject _arrows = Instantiate(_arrowsobj);

        _arrows.transform.position = transform.position;

        _arrows.transform.Rotate(Vector3.up * angle);

        _jiantou.Add(_arrows);


    }

    /// <summary>
    /// 全部撤销
    /// </summary>
    /// <param name="ob"></param>
    void AllRevocation(object ob)
    {

        //回到回合开始的地方
        transform.position = CurrTransform;

        string str = string.Format("撤销全部 当前位置{0},行:{2},列{3}，初始位置{1}", transform.position, CurrTransform, _playerInfo.Hang, _playerInfo.Lie);

        Debug.Log(str);

        _playerInfo.Hang = (int)transform.position.z / _playerInfo.MoveDistance;

        _playerInfo.Lie = (int)transform.position.x / _playerInfo.MoveDistance;

        //清空已操作的数据
        _gameData.Clear();


        //清空移动箭头
        for(int i = 0; i < _jiantou.Count; i++)
        {
            GameObject _arrows = _jiantou[i];
            Destroy(_arrows);
        }
        _jiantou.Clear();

        //清空攻击物体
        for (int i = 0; i < _attack.Count; i++)
        {
            GameObject _attackobj = _attack[i];
            Destroy(_attackobj);
        }
        _attack.Clear();

    }


    /// <summary>
    /// 回合开始
    /// </summary>
    /// <param name="ob"></param>
    void HuiHeStar(object ob)
    {
        _playerInfo.StepNum = 0;

        _playerInfo.AttackNum = 0;

        CurrTransform = this.transform.position;

       

        string str = string.Format("回合开始 初始位置{0},行:{1},列{2}", CurrTransform, _playerInfo.Hang, _playerInfo.Lie);

        Debug.Log(str);

    }


    /// <summary>
    /// 回合结束
    /// </summary>
    /// <param name="ob"></param>
    void HuiHeOver(object ob)
    {


        ReceiveData.Instance.IsHuihe = false;

        //生成旗子
        GameObject _flagsobj = Resources.Load<GameObject>("Model/Flag/Flag");

        GameObject _flag = Instantiate(_flagsobj);

        _flag.transform.position = transform.position;

        _jiantou.Add(_flag);

        //回到回合开始的地方
        transform.position = CurrTransform;

        string str = string.Format("回合结束 当前位置{0} , 行:{2},列{3} ，初始位置{1}", transform.position, CurrTransform, _playerInfo.Hang, _playerInfo.Lie);

        Debug.Log(str);


        ////重置行列
        //_playerInfo.Hang = (int)transform.position.z / _playerInfo.MoveDistance;

        //_playerInfo.Lie = (int)transform.position.x / _playerInfo.MoveDistance;

        UICtr.Instance.UIHide();


        //发送所有操作给服务器
         //GameControl.Instance.AddGameData(_gameData);

        

        GameControl.Instance.AllGameData = _gameData;


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
        GameControl.Instance.Cub.AttackBianSe(_playerInfo.Hang + 0, _playerInfo.Lie - 1);
        GameControl.Instance.Cub.AttackBianSe(_playerInfo.Hang - 1, _playerInfo.Lie + 1);
        GameControl.Instance.Cub.AttackBianSe(_playerInfo.Hang - 1, _playerInfo.Lie - 1);
        GameControl.Instance.Cub.AttackBianSe(_playerInfo.Hang + 1, _playerInfo.Lie + 1);
        GameControl.Instance.Cub.AttackBianSe(_playerInfo.Hang + 1, _playerInfo.Lie - 1);

    }






   public void PlayAnimation(List<OverSend> os)
    {
        //清空移动箭头
        for (int i = 0; i < _jiantou.Count; i++)
        {
            GameObject _arrows = _jiantou[i];
            Destroy(_arrows);
        }
        _jiantou.Clear();


        //播放动画
        StartCoroutine(StarAnimation(os));

    }

    IEnumerator StarAnimation(List<OverSend> os)
    {
        _ani = 0;
        while (_ani < os.Count)
        {
          
                OverSend ndata = new OverSend();
                ndata = os[_ani];
                Vector3 weizhi = new Vector3(ndata.byLie * _playerInfo.MoveDistance, transform.position.y, ndata.byHang * _playerInfo.MoveDistance);


                Tweener _tweener;
                _tweener=transform.DOMove(weizhi, 1.5f);
                _tweener.SetEase(Ease.Linear);
            
                _ani++;
            yield return new WaitForSeconds(1.5f);
        }
        //List<OverSend> ob = new List<OverSend>();
        StopCoroutine("StarAnimation");

    }


    public void StarInit()
    {


        //清空已操作的数据
        _gameData.Clear();

        //初始化步数
        _playerInfo.StepNum = 0;

        //初始化攻击次数
        _playerInfo.AttackNum = 0;

        CurrTransform = new Vector3(_playerInfo.Lie * _playerInfo.MoveDistance, transform.position.y, _playerInfo.Hang * _playerInfo.MoveDistance);

    }




    ///// <summary>
    ///// 显示攻击范围
    ///// </summary>
    ///// <param name="i"></param>
    ///// <param name="j"></param>
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

    ///// <summary>
    ///// 初始化方块
    ///// </summary>
    ///// <param name="ob"></param>
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
