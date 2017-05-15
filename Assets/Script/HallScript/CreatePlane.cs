using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlane : MonoBehaviour {


    private Button _freeBtn;

    private Button _teamBtn;

    private Button _exitBtn;




    private void Awake()
    {

        Find();

        AddListen();
    }
    // Use this for initialization
    void Start () {
		
	}
	
    void Find()
    {
                    
        _freeBtn = transform.Find("FreeBtn").GetComponent<Button>();

        _teamBtn = transform.Find("TeamBtn").GetComponent<Button>();

        _exitBtn = transform.Find("ExitBtn").GetComponent<Button>();

        _exitBtn = transform.Find("ExitBtn").GetComponent<Button>();





    }

    void AddListen()
    {
        _freeBtn.onClick.AddListener(FreeClick);

        _teamBtn.onClick.AddListener(TeamClick);

        _exitBtn.onClick.AddListener(ExitClick);

    }

    void FreeClick()
    {
        Application.LoadLevelAsync("RoomScene");
    }
    void TeamClick()
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
