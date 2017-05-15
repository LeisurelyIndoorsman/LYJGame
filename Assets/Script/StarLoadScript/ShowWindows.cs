using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LWSocket;

public class ShowWindows : MonoBehaviour {


    static ShowWindows Instance;





    private void Awake()
    {
        SocketTest.AsynConnect();
    }
    // Use this for initialization
    void Start () {
        //CreateWindows();
        DontDestroyOnLoad(this.gameObject);

    }


    public static void CreateWindows()
    {
        

        if (Instance == null)
        {
            GameObject windowobj = GameObject.Instantiate(Resources.Load<GameObject>("UI/ShowWindows"));
            //GameObject texttip = Resources.Load<GameObject>("UI/PropWindow");
            //GameObject tip = GameObject.Instantiate<GameObject>(texttip);
            windowobj.transform.localEulerAngles = Vector3.zero;
            windowobj.transform.localScale = Vector3.one;
            windowobj.transform.localPosition = Vector3.zero;
            //windowobj.AddComponent<Windows>();


        }
        // GameObject tip = GameObject.Instantiate<GameObject>(texttip);

    }


    // Update is called once per frame
    void Update () {
		
	}
}
