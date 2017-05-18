using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameMessage {

 
}


/// <summary>
/// 回合结束发给服务器的数据
/// </summary>
/// 
[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct OverSend
{


    public int byType;     // 操作类型 （0.移动 1.攻击 2.技能）


    public int byHang;

    public int byLie;

}


