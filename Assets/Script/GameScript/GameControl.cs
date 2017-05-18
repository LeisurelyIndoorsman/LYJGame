using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl:MonoBehaviour{


 


    public static GameControl Instance;



    public CubCtr Cub;

    private GameObject player;

    public List<SoldierCtr> GamePlayer = new List<SoldierCtr>();


    public List<OverSend> AllGameData = new List<OverSend>();



    private void Awake()
    {
        Instance = this;
        Find();
        AddListen();
        
    }

    private void Start()
    {

        SfAddEvent.Instance.Trigger((int)ProtocalID.HuiHeStar_Main);//执行回合开始
        GamePlayer.Add(player.GetComponent<SoldierCtr>());

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            SfAddEvent.Instance.Trigger((int)ProtocalID.SeverHuiHeStar_Main);//执行回合开始
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SfAddEvent.Instance.Trigger((int)ProtocalID.SeverHuiHeOver_Main);//执行回合结束
        }
        

    }

    void Find()
    {
        player = GameObject.Find("Soldier");

    }
    void AddListen()
    {

        SfAddEvent.Instance.Add((int)ProtocalID.SeverHuiHeStar_Main, HuiHeStar);//回合开始

        SfAddEvent.Instance.Add((int)ProtocalID.SeverHuiHeOver_Main, HuiHeOver);//服务器确认所有玩家都结束回合


    }



    //public void AddGameData(List<OverSend> os)
    //{
    //    AllGameData = os;
    //    GamePlayer[0].PlayAnimation(AllGameData);
    //}
    void HuiHeStar(object ob)
    {

        UICtr.Instance.StarInit();
        GamePlayer[0].StarInit();



    }


    void HuiHeOver(object ob)
    {


        GamePlayer[0].PlayAnimation(AllGameData);



    }

}
