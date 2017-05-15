using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tools;

public class ShowBox : MonoBehaviour {

   // public delegate void CallBack();

    private CallBack okWay;

    private CallBack cancelWay;

    public static ShowBox Instance = null;
    //static ShowBox _instance;

    //public static ShowBox Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            _instance = new ShowBox();
    //        }
    //        return _instance;
    //    }
    //}

    private Text boxText;

    private Button okBtn;

    private Button _okBtn;

    private Button _cancelBtn;

    private void Awake()
    {
        Instance = this;

        Find();

        AddListen();

        transform.GetComponent<RectTransform>().localScale=Vector3.zero;
    }

    void Find()
    {

        boxText = transform.Find("TishiText").GetComponent<Text>();

        okBtn= transform.FindChild("OkBtn").GetComponent<Button>();

        _okBtn = transform.FindChild("_OkBtn").GetComponent<Button>();

        _cancelBtn = transform.FindChild("_CancelBtn").GetComponent<Button>();

        //LoginCtr.Instance.TishiJB = transform.GetComponent<ShowBox>();

    }

    void AddListen()
    {
        okBtn.onClick.AddListener(Hide);

        _okBtn.onClick.AddListener(Hide);

        _cancelBtn.onClick.AddListener(Hide);



    }

    void Hide()
    {
        if (okWay!=null)
        {
            okWay();
        }

        if (cancelWay != null)
        {
            cancelWay();
        }


        transform.GetComponent<RectTransform>().localScale = Vector3.zero;

        //this.gameObject.SetActive(false);

    }



    public void Show(int i,string str,CallBack okClick=null, CallBack cancelClick = null)
    {

        if (i == 1)
        {
            okBtn.gameObject.SetActive(true);
            _okBtn.gameObject.SetActive(false);
            _cancelBtn.gameObject.SetActive(false);
        }
        else
        {
            okBtn.gameObject.SetActive(false);
            _okBtn.gameObject.SetActive(true);
            _cancelBtn.gameObject.SetActive(true);
        }

        okWay = null;

        cancelWay = null;

        if (okClick != null)
            okWay = okClick;

        if (cancelClick != null)
            cancelWay = cancelClick;

        transform.GetComponent<RectTransform>().localScale = Vector3.one;

        boxText.text = str;
        
    }

   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
