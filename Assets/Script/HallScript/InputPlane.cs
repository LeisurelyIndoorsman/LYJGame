using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputPlane : MonoBehaviour {


    private Button _okBtn;

    private Button _cancelBtn;

    private InputField _inputFangHao;


    private void Awake()
    {

        _okBtn = transform.Find("OKBtn").GetComponent<Button>();

        _okBtn.onClick.AddListener(OkClick);

        _cancelBtn = transform.Find("CancelBtn").GetComponent<Button>();

        _cancelBtn.onClick.AddListener(CancelClick);

        _inputFangHao= transform.Find("InputField").GetComponent<InputField>();


    }

    void OkClick()
    {

        int roomId=0;

        if (_inputFangHao.text != "")
        {
            roomId = int.Parse(_inputFangHao.text);
        }
        else
        {
            ShowBox.Instance.Show(1,"请输入房号",null);
        }
       

        //Debug.Log(roomId);

    }

    void CancelClick()
    {

        this.gameObject.SetActive(false);

    }
    // Use this for initialization
    void Start () {
		
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
