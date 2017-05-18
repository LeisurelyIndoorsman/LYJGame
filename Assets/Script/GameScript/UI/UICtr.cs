using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICtr : MonoBehaviour {


    public static UICtr Instance = null;

    public Button _moveBtn;

    public Button _attackBtn;

    public Button _skillBtn;

    public Button _backBtn;

    private Button _obBtn;

    private Button _ctrBtn;

    private Button _overBtn;

    private Button _revocationBtn;

    private Button _allrevocationBtn;

    private Text _huiHe;

    private int _currHuiHe=0;

    private Text _time;

    private float _timer;

    private Text _step;

    private Transform _direction;

    private GameObject _userList;

    public GameObject _player;






    private void Awake()
    {

        Instance = this;

        Find();

        AddListen();

    }

    private void Update()
    {

        if (ReceiveData.Instance.IsHuihe)
        {

            _timer -= Time.deltaTime;

            _time.text = ((int)_timer).ToString();

            _step.text = GameControl.Instance.GamePlayer[0]._remainStep.ToString();

        }
        

    }

    public void StarInit()
    {

        ReceiveData.Instance.IsHuihe = true;

        _timer = 99;

        _currHuiHe++;

        _huiHe.text=_currHuiHe.ToString();

        UIShow();
        


    }

     void UIShow()
    {
       
        _userList.SetActive(true);
        _moveBtn.gameObject.SetActive(true);
        _attackBtn.gameObject.SetActive(true);
        _skillBtn.gameObject.SetActive(true);
        _direction.gameObject.SetActive(false);
        _backBtn.gameObject.SetActive(false);
        _overBtn.gameObject.SetActive(true);
        _obBtn.gameObject.SetActive(true);
        _ctrBtn.gameObject.SetActive(false);
        _revocationBtn.gameObject.SetActive(true);
        _allrevocationBtn.gameObject.SetActive(true);

    }

    public void UIHide()
    {
        _userList.SetActive(false);
        _moveBtn.gameObject.SetActive(false);
        _attackBtn.gameObject.SetActive(false);
        _skillBtn.gameObject.SetActive(false);
        _direction.gameObject.SetActive(false);
        _backBtn.gameObject.SetActive(false);
        _overBtn.gameObject.SetActive(false);
        _obBtn.gameObject.SetActive(false);
        _ctrBtn.gameObject.SetActive(false);
        _revocationBtn.gameObject.SetActive(false);
        _allrevocationBtn.gameObject.SetActive(false);
    }

    void Find()
    {
        
        _userList = transform.FindChild("UserList").gameObject;
        _time = transform.FindChild("Time").GetComponent<Text>();
        _step = transform.FindChild("StepNum").GetComponent<Text>();
        _huiHe = transform.FindChild("HuiheNum").GetComponent<Text>();
        _moveBtn = transform.FindChild("PlayerBtn/MoveBtn").GetComponent<Button>();
        _attackBtn = transform.FindChild("PlayerBtn/AttackBtn").GetComponent<Button>();
        _skillBtn = transform.FindChild("PlayerBtn/SkillBtn").GetComponent<Button>();
        _backBtn = transform.Find("PlayerBtn/BackBtn").GetComponent<Button>();
        _revocationBtn = transform.FindChild("PlayerBtn/RevocationBtn").GetComponent<Button>();
        _allrevocationBtn = transform.FindChild("PlayerBtn/AllRevocationBtn").GetComponent<Button>();
        _obBtn = transform.FindChild("PlayerBtn/ObserveBtn").GetComponent<Button>();
        _ctrBtn = transform.FindChild("PlayerBtn/ControlBtn").GetComponent<Button>();
        _overBtn = transform.FindChild("PlayerBtn/OverBtn").GetComponent<Button>();
        _direction = transform.FindChild("PlayerBtn/Direction");

    }

    void AddListen()
    {
        _moveBtn.onClick.AddListener(MoveClick);
        _attackBtn.onClick.AddListener(AttackClick);
        _skillBtn.onClick.AddListener(SkillClick);
        _backBtn.onClick.AddListener(BackClick);
        _revocationBtn.onClick.AddListener(RevocationClick);
        _allrevocationBtn.onClick.AddListener(AllRevocationClick);
        _obBtn.onClick.AddListener(ObServeClick);
        _ctrBtn.onClick.AddListener(CtrClick);
        _overBtn.onClick.AddListener(OverClick);
    }

    void MoveClick()
    {
        _moveBtn.gameObject.SetActive(false);
        _attackBtn.gameObject.SetActive(false);
        _skillBtn.gameObject.SetActive(false);
        _direction.gameObject.SetActive(true);
        _backBtn.gameObject.SetActive(true);
    }

    void AttackClick()
    {
        _moveBtn.gameObject.SetActive(false);
        _attackBtn.gameObject.SetActive(false);
        _skillBtn.gameObject.SetActive(false);
        _direction.gameObject.SetActive(false);
        _backBtn.gameObject.SetActive(true);
        SfAddEvent.Instance.Trigger((int)ProtocalID.Attack_Main);


    }

    void SkillClick()
    {
        
    }
    public void BackClick()
    {

        _moveBtn.gameObject.SetActive(true);
        _attackBtn.gameObject.SetActive(true);
        _skillBtn.gameObject.SetActive(true);
        _direction.gameObject.SetActive(false);
        _backBtn.gameObject.SetActive(false);
        //SfAddEvent.Instance.Trigger((int)ProtocalID.CubInit_Main);
    }


    void CtrClick()
    {
        UIShow();
    }

    void ObServeClick()
    {
        UIHide();
        _ctrBtn.gameObject.SetActive(true);
    }

    void RevocationClick()
    {

    }
    void AllRevocationClick()
    {
        SfAddEvent.Instance.Trigger((int)ProtocalID.AllRevocation_Main);
    }
    void OverClick()
    {
        _moveBtn.gameObject.SetActive(false);
        _attackBtn.gameObject.SetActive(false);
        _skillBtn.gameObject.SetActive(false);
        _direction.gameObject.SetActive(false);
        SfAddEvent.Instance.Trigger((int)ProtocalID.HuiHeOver_Main);
    }

}
