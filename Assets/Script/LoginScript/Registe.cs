using LWSocket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Registe : MonoBehaviour {



    private Transform accoutKuang;

    private Transform passwordKuang;

    private Transform repasswordKuang;

    private Button okBtn;

    private Button cancelBtn;

    private string _accoutText;

    private string _passwordText;

    private string _repasswordText;

    //private ShowBox box;
    private void Awake()
    {
        Find();
        AddListen();

        gameObject.SetActive(false);
    }

    void Find()
    {

        LoginCtr.Instance.registeWT = gameObject;

        //box = GameObject.Find("TishiKuang").GetComponent<ShowBox>();

        accoutKuang = transform.FindChild("AccoutKuang");
        passwordKuang = transform.FindChild("PasswordKuang");
        repasswordKuang = transform.FindChild("RepasswordKuang");
       
        okBtn = transform.FindChild("OkBtn").GetComponent<Button>();
        cancelBtn = transform.FindChild("CancelBtn").GetComponent<Button>();

    }

    void AddListen()
    {
        okBtn.onClick.AddListener(OkWay);
        cancelBtn.onClick.AddListener(CancelWay);

    }


    /// <summary>
    /// 确定注册
    /// </summary>
    void OkWay()
    {
        _accoutText = accoutKuang.GetComponent<InputField>().text;
        _passwordText = passwordKuang.GetComponent<InputField>().text;
        _repasswordText = repasswordKuang.GetComponent<InputField>().text;
        //_accoutText = _accoutText.Replace(" ", "");
        //_passwordText = _passwordText.Replace(" ", "");
        //_repasswordText = _repasswordText.Replace(" ", "");

         if(_accoutText.Contains(" "))
        {
            LoginCtr.Instance.TishiShow("账号或密码有不合规定的字符");
        }
        else if (_passwordText!= _repasswordText && _passwordText!="")
        {
           
            LoginCtr.Instance.TishiShow("两次输入密码不一致");

        }
        else if(_accoutText!="" && _passwordText != "")
        {

            
            string accoutData = PlayerPrefs.GetString(_accoutText, "Default");
            if (accoutData != "Default")
            {
                LoginCtr.Instance.TishiShow("账号已被注册");
            }
            else
            {
                PlayerPrefs.SetString(_accoutText, _accoutText);
                PlayerPrefs.SetString(_accoutText+"密码", _passwordText);
                PlatFormSocket.Instance.ReRegiste(_accoutText, _passwordText);
                LoginCtr.Instance.TishiShow("注册成功", LoadScene);
            }

        }
        else
        {
            LoginCtr.Instance.TishiShow("账号或者密码不能为空");
        }
        
       
        
    }

    void LoadScene()
    {

        ReceiveData.Instance.nameText = _accoutText;

        Application.LoadLevelAsync("HallScene");

    }

    /// <summary>
    /// 取消注册
    /// </summary>
    void CancelWay()
    {
        LoginCtr.Instance.LoginShow();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
