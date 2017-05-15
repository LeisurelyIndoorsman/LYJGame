using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtr : MonoBehaviour {


    public Transform _player;

    private Vector3 offset;

    // Use this for initialization  
    void Start()
    {


        offset = transform.position - _player.position;  //计算初始物体与相机的偏移距离  



    }

    // Update is called once per frame  
    void Update()
    {

        
        transform.position = Vector3.Lerp(transform.position, _player.position + offset,5 * Time.deltaTime) ;   //运动物体当前位置 加上 原始偏移  



    }

}
