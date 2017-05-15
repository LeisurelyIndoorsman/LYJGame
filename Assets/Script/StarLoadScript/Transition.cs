using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour {

    //private Transform _jinDu1;

    private Slider _jinDu;

    //private string hehe;
    

    void Awake()
    {

        Find();

        ShowWindows.CreateWindows();

    }

    void Find()
    {
        //hehe = transform.FindChild("Text").GetComponent<Text>().text;
        _jinDu = transform.FindChild("Jindu").GetComponent<Slider>();
        _jinDu.value = 0;



    }


    
	// Use this for initialization
	void Start () {

        LoadZiYuan();

    }

    void LoadZiYuan()
    {
        

        

    }

	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    Debug.Log(hehe);
        //}
        _jinDu.value += Time.deltaTime / 2;

        if (_jinDu.value == 1)
            Application.LoadLevelAsync("LoginScene");

    }
}
