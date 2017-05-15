using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LWSocket;


public class Login : MonoBehaviour {

    //public Text _userName;

   
    private Transform accoutKuang;

    private Transform passwordKuang;


    private string _accoutText;

    private string _passwordText;




    private Button _loginBtn;

    private Button _registerBtn;


    private void Awake()
    {

        FindWuti();

        AddListen();
       
    }


    void FindWuti()
    {

        LoginCtr.Instance.loginWt = gameObject;
      
        accoutKuang =transform.FindChild("AccoutKuang");

        passwordKuang = transform.FindChild("PasswordKuang");

        

        _loginBtn = transform.FindChild("LoginBtn").GetComponent<Button>();

        _registerBtn = transform.FindChild("RegisterBtn").GetComponent<Button>();

    }

    void AddListen()
    {

        _loginBtn.onClick.AddListener(LoginClick);

        _registerBtn.onClick.AddListener(RegisterWay);
    }


    void LoginClick()
    {

        string accout;

        string password;

        _accoutText = accoutKuang.GetComponent<InputField>().text;

        _passwordText = passwordKuang.GetComponent<InputField>().text;

        accout =PlayerPrefs.GetString(_accoutText, "default");

        password = PlayerPrefs.GetString(_accoutText+"密码", "default");

        if(accout == ""|| password == "")
        {

            LoginCtr.Instance.TishiShow("账号或密码不能为空");

        }else if (accout=="default")
        {

            LoginCtr.Instance.TishiShow("该账号还没注册");

        }
        else if(accout!= _accoutText|| password!= _passwordText)
        {

            LoginCtr.Instance.TishiShow("账号或密码错误");

        }
        else
        {

            PlatFormSocket.Instance.ReLogin(accout,password);

            LoginCtr.Instance.TishiShow("登录成功",LoadScene);

        }
       
       
        


    }

  

    void LoadScene()
    {
        ReceiveData.Instance.nameText = _accoutText;


        Application.LoadLevelAsync("HallScene");
    }



    void RegisterWay()
    {
        LoginCtr.Instance.RegisteShow();
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
