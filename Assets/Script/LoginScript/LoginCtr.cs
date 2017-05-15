using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;


public class LoginModel
{
    string _name;
    string _userName;
    string _password;
    //sex,
}

public class LoginCtr {

    static LoginCtr _instance;
    public static LoginCtr Instance
    {
        get { if (_instance == null)
                _instance = new LoginCtr();
            return _instance;
        }
    }

    // private Login _view;

    //private LoginModel _model;

    /// <summary>
    /// 提示脚本
    /// </summary>
    //public ShowBox TishiJB;


    /// <summary>
    /// 注册框物体
    /// </summary>
    public GameObject registeWT;


    /// <summary>
    /// 登录框物体
    /// </summary>
    public GameObject loginWt;


    public void LoginShow()
    {
        loginWt.SetActive(true);
        registeWT.SetActive(false);
    }

    public void RegisteShow()
    {
        loginWt.SetActive(false);
        registeWT.SetActive(true);
    }

    public void TishiShow(string str,CallBack way=null)
    {
        if (way != null)
        {
            ShowBox.Instance.Show(1,str, way);
        }
        else
        {
            ShowBox.Instance.Show(1,str,null);
        }
        

    }

    public void WXLogin()
    {
      
    }
}
