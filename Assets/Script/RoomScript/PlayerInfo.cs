using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {


    private Text nameText;


    private void Awake()
    {
        Find();
        Show();

    }

   

    void Find()
    {
        nameText = transform.Find("NameBeijing/Text").GetComponent<Text>();

    }

    private void Show()
    {
        nameText.text = ReceiveData.Instance.nameText;
    }


}
