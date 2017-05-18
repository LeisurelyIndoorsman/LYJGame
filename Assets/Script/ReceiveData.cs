using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveData {


    public static ReceiveData Instance
    {
        
        get
        {
            if (_instance == null)
            {

                _instance = new ReceiveData();
            }
            return _instance;
        }
    }

    private static ReceiveData _instance;

    /// <summary>
    /// 玩家名字
    /// </summary>
    public string nameText;

    /// <summary>
    /// 玩家ID
    /// </summary>
    public int nameID=100;

    /// <summary>
    /// 回合开始还是结束
    /// </summary>
    public bool IsHuihe = false;
    

}
