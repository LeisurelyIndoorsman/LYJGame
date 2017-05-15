using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum MoveType
{
    Up,       //向上
    Down,      //向下
    Left,     //向左
    Right    //向右
    
}



public interface IEvent
{

    int Type { get; }

    SfAddEvent.callback cb { get; set; }

}

public class UpEvent : IEvent
{
    public int Type
    {
        get
        {
            return (int)MoveType.Up;
        }
    }
    public SfAddEvent.callback cb
    {
        get
        {
            return _cb;
        }

        set
        {
            _cb = value;
        }
    }

    private SfAddEvent.callback _cb;
}
public class DownEvent : IEvent
{
    public int Type
    {
        get
        {
            return (int)MoveType.Down;
        }
    }
    public SfAddEvent.callback cb
    {
        get
        {
            return _cb;
        }

        set
        {
            _cb = value;
        }
    }

    private SfAddEvent.callback _cb;
}

public class LeftEvent : IEvent
{
    public int Type
    {
        get
        {
            return (int)MoveType.Left;
        }
    }
    public SfAddEvent.callback cb
    {
        get
        {
            return _cb;
        }

        set
        {
            _cb = value;
        }
    }

    private SfAddEvent.callback _cb;
}
public class RightEvent : IEvent
{
    public int Type
    {
        get
        {
            return (int)MoveType.Right;
        }
    }
    public SfAddEvent.callback cb
    {
        get
        {
            return _cb;
        }

        set
        {
            _cb = value;
        }
    }

    private SfAddEvent.callback _cb;
}




public class SfAddEvent {



    private static SfAddEvent _instance;

    public static SfAddEvent Instance
    {
        get
        {
            if (_instance == null)
            {

                _instance = new SfAddEvent();
            }
            return _instance;
        }
    }




    public delegate void callback(object ob);
    Dictionary<int, callback> dict = new Dictionary<int, callback>();



    public void Add(int id, callback cb)
    {
        dict.Add(id, cb);
        string str = string.Format("监听 mainID:{0} ", id);
        Debug.Log(str);
    }
    public void Add(IEvent eve)
    {
        dict.Add(eve.Type, eve.cb);
    }


    public void Trigger(int mainID)
    {
        if (dict.ContainsKey(mainID))
        {
            dict[mainID](null);

        }
        else
        {
            string str = string.Format("没有监听 mainID:{0}", mainID);
            Debug.Log(str);
        }
       

    }
    public void Trigger(int mainID,IEvent e)
    {
        int type = e.Type;
        
        dict[mainID](type);
    }

    



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
