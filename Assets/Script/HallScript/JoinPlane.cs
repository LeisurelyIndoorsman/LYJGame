using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinPlane : MonoBehaviour {


    private Button _inputBtn;

    private Button _shuaXinBtn;

    private Button _exitBtn;

    private GameObject InputPlane;





    private void Awake()
    {

        Find();

        AddListenr();

    }

    // Use this for initialization
    void Start () {
		
	}

    void Find()
    {

        _inputBtn = transform.Find("InputBtn").GetComponent<Button>();

        _shuaXinBtn = transform.Find("ShauaxinBtn").GetComponent<Button>();

        _exitBtn = transform.Find("ExitBtn").GetComponent<Button>();

        InputPlane= transform.Find("Inputfanghao").gameObject;

        InputPlane.SetActive(false);


    }

    void AddListenr()
    {

        _inputBtn.onClick.AddListener(InputClick);

        _shuaXinBtn.onClick.AddListener(ShuaXinClick);

        _exitBtn.onClick.AddListener(ExitClick);

    }
	
    void InputClick()
    {

        InputPlane.SetActive(true);

    }
    void ShuaXinClick()
    {

    }

    void ExitClick()
    {

        this.gameObject.SetActive(false);

    }

	// Update is called once per frame
	void Update () {
		
	}
}
