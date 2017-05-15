using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallControl : MonoBehaviour {

    private Button _createRoomBtn;

    private Button _joinRoomBtn;

    private GameObject _createPlane;
   
    private GameObject _joinPlane;


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

        _createRoomBtn = transform.Find("CreateRoomBtn").GetComponent<Button>();

        _joinRoomBtn = transform.Find("JoinRoomBtn").GetComponent<Button>();

        _createPlane= transform.Find("CreatePlane").gameObject;

        if (_createPlane!=null) _createPlane.SetActive(false);

        _joinPlane = transform.Find("JoinPlane").gameObject;

        if (_joinPlane != null) _joinPlane.SetActive(false);

    }

    void AddListen()
    {
        _createRoomBtn.onClick.AddListener(CreateRoom);

        _joinRoomBtn.onClick.AddListener(JoinRoom);
    }

    void CreateRoom()
    {
        _createPlane.SetActive(true);
    }
    void JoinRoom()
    {
        _joinPlane.SetActive(true);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
