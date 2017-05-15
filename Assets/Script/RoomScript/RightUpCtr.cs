using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightUpCtr : MonoBehaviour {


    private Button _musicBtn;

    private Button _setBtn;

    private Button _backBtn;



    private void Awake()
    {

        Find();

        AddListen();

    }

    void Find()
    {
        _backBtn = transform.FindChild("BackBtn").GetComponent<Button>();

    }

    void AddListen()
    {
        _backBtn.onClick.AddListener(BackClick);
    }


    void BackClick()
    {
        ShowBox.Instance.Show(2, "是否退出房间", BackHall);
        
    }

    void BackHall()
    {
        Application.LoadLevelAsync("HallScene");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
