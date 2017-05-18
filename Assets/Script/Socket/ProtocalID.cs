using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



   public class ProtocalID
    {


    /// <summary>
    /// 注册的主ID
    /// </summary>
    public const uint Registe_Main = 1;
    /// <summary>
    /// 注册的副ID
    /// </summary>
    public const uint Registe_Ass = 1;

    /// <summary>
    /// 登录的主ID
    /// </summary>
    public const uint Login_Main = 2;
    /// <summary>
    /// 登录的副ID
    /// </summary>
    public const uint Login_Ass = 1;



    /// <summary>
    /// 游戏开始
    /// </summary>
    public const uint GameStar_Main = 3;

    /// <summary>
    /// 回合开始
    /// </summary>
    public const uint HuiHeStar_Main = 4;

    /// <summary>
    /// 玩家移动
    /// </summary>
    public const uint Move_Main = 5;

    /// <summary>
    /// 玩家攻击
    /// </summary>
    public const uint Attack_Main = 6;

    ///// <summary>
    ///// 还原颜色
    ///// </summary>
    //public const uint CubInit_Main = 7;

    /// <summary>
    /// 撤销一步
    /// </summary>
    public const uint Revocation_Main = 8;

    /// <summary>
    /// 撤销全部
    /// </summary>
    public const uint AllRevocation_Main = 9;

    /// <summary>
    /// 回合结束
    /// </summary>
    public const uint HuiHeOver_Main = 10;


    /// <summary>
    /// 服务器发送回合开始
    /// </summary>
    public const uint SeverHuiHeStar_Main = 100;

    /// <summary>
    /// 服务器发送回合结束
    /// </summary>
    public const uint SeverHuiHeOver_Main = 101;


}

