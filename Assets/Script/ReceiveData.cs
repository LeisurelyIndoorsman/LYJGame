using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveData {


    public static ReceiveData Instance
    {
        
        get
        {
            if (_instance == null)
            {

                _instance = new ReceiveData();
            }
            return _instance;
        }
    }

    private static ReceiveData _instance;


    public string nameText;

    public int nameID=100;
   
    

}
