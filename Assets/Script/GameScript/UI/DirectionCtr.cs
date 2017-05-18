using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionCtr : MonoBehaviour {

    private Button _upBtn;

    private Button _downBtn;

    private Button _leftBtn;

    private Button _rightBtn;










    private void Awake()
    {

        Find();

        AddListen();

    }

    void Find()
    {
        _upBtn = transform.FindChild("UpBtn").GetComponent<Button>();
        _downBtn = transform.FindChild("DownBtn").GetComponent<Button>();
        _leftBtn = transform.FindChild("LeftBtn").GetComponent<Button>();
        _rightBtn = transform.FindChild("RightBtn").GetComponent<Button>();



    }

    void AddListen()
    {
        _upBtn.onClick.AddListener(UpClick);
        _downBtn.onClick.AddListener(DownClick);
        _leftBtn.onClick.AddListener(LeftClick);
        _rightBtn.onClick.AddListener(RightClick);

    }

    void UpClick()
    {
        IEvent eve = new UpEvent();
        SfAddEvent.Instance.Trigger((int)ProtocalID.Move_Main, eve);

        string str = string.Format("向前 mainID:{0}", eve.Type);
        Debug.Log(str);
    }
    void DownClick()
    {
        IEvent eve = new DownEvent();
        SfAddEvent.Instance.Trigger((int)ProtocalID.Move_Main, eve);
        string str = string.Format("向后 mainID:{0} ", eve.Type);
        Debug.Log(str);
    }

    void LeftClick()
    {
        IEvent eve = new LeftEvent();
        SfAddEvent.Instance.Trigger((int)ProtocalID.Move_Main,eve);
        string str = string.Format("向左 mainID:{0} ", eve.Type );
        Debug.Log(str);
    }
    void RightClick()
    {
        IEvent eve = new RightEvent();
        SfAddEvent.Instance.Trigger((int)ProtocalID.Move_Main,eve);
        string str = string.Format("向右 mainID:{0} ", eve.Type);
        Debug.Log(str);
    }


}
