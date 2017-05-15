using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightDownCtr : MonoBehaviour {


    private Button _readyBtn;

    private Button _cancelBtn;

    private Button _starBtn;



    private void Awake()
    {

        Find();

        AddListen();

    }

    void Find()
    {
        _readyBtn = transform.Find("ReadyBtn").GetComponent<Button>();
        _cancelBtn = transform.Find("CancelBtn").GetComponent<Button>();
        _starBtn = transform.Find("StarBtn").GetComponent<Button>();
        _readyBtn.gameObject.SetActive(true);
        _cancelBtn.gameObject.SetActive(false);
        _starBtn.gameObject.SetActive(false);

    }

    void AddListen()
    {
        _readyBtn.onClick.AddListener(ReadyClick);
        _cancelBtn.onClick.AddListener(CancelClick);
        _starBtn.onClick.AddListener(StarClick);
    }

    void ReadyClick()
    {
        _readyBtn.gameObject.SetActive(false);
        _cancelBtn.gameObject.SetActive(true);
        _starBtn.gameObject.SetActive(false);
    }
    void CancelClick()
    {
        _readyBtn.gameObject.SetActive(true);
        _cancelBtn.gameObject.SetActive(false);
        _starBtn.gameObject.SetActive(false);
    }
    void StarClick()
    {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
