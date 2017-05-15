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

    private Button _overBtn;

    private Button _revocationBtn;

    private Transform _direction;

    public GameObject _player;






    private void Awake()
    {

        Instance = this;

        Find();

        AddListen();

    }

    void Find()
    {
        _moveBtn = transform.FindChild("PlayerBtn/MoveBtn").GetComponent<Button>();
        _attackBtn = transform.FindChild("PlayerBtn/AttackBtn").GetComponent<Button>();
        _skillBtn = transform.FindChild("PlayerBtn/SkillBtn").GetComponent<Button>();
        _backBtn = transform.Find("PlayerBtn/BackBtn").GetComponent<Button>();
        _revocationBtn = transform.FindChild("PlayerBtn/RevocationBtn").GetComponent<Button>();
        _obBtn = transform.FindChild("PlayerBtn/ObserveBtn").GetComponent<Button>();
        _overBtn = transform.FindChild("PlayerBtn/OverBtn").GetComponent<Button>();
        _direction = transform.FindChild("PlayerBtn/Direction");


    }

    void AddListen()
    {
        _moveBtn.onClick.AddListener(MoveClick);
        _attackBtn.onClick.AddListener(AttackClick);
        _skillBtn.onClick.AddListener(SkillClick);
        _backBtn.onClick.AddListener(BackClick);
        _revocationBtn.onClick.AddListener(OverClick);
        _obBtn.onClick.AddListener(ObServeClick);
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
        SfAddEvent.Instance.Trigger((int)ProtocalID.Move_Attack);


    }

    void SkillClick()
    {
        
    }
    void BackClick()
    {

        _moveBtn.gameObject.SetActive(true);
        _attackBtn.gameObject.SetActive(true);
        _skillBtn.gameObject.SetActive(true);
        _direction.gameObject.SetActive(false);
        _backBtn.gameObject.SetActive(false);
        SfAddEvent.Instance.Trigger((int)ProtocalID.Move_CubInit);
    }

    void ObServeClick()
    {

    }

    void OverClick()
    {
        _moveBtn.gameObject.SetActive(false);
        _attackBtn.gameObject.SetActive(false);
        _skillBtn.gameObject.SetActive(false);
        _direction.gameObject.SetActive(false);
    }

}
