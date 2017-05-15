using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoubin : MonoBehaviour {



    Vector2 _ve2MousePos;
    private void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TuoZhuai);
    }
    // Use this for initialization
    void Start () {

        //switch (0)
        //{
        //    case 0:
        //       // break;
        //    case 1:
        //       // break;
        //    case 2:
        //        print(2);
        //        break;
        //    case 3:

        //        print(3);
        //        break;
        //}
       
    }

    void TuoZhuai()
    {
        
    }
	
    IEnumerator Show()
    {
        yield return new WaitForSeconds(1);
        while (Input.GetKey(KeyCode.Mouse0))
        {
            _ve2MousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            print(_ve2MousePos);
        }
    }
	// Update is called once per frame
	void Update () {

        


    }

}
