using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPlayerInfo
{
    public int Hang=0;

    public int Lie=0;

    public int StepNum = 0;

    public int AttackNum = 0;

    public int MaxStepNum=10;

    public int MoveDistance = 7;

    public int MaxAttackNum;

    public int NameID;



    public OverSend SendData;

    public static GPlayerInfo SoldierInit( )
    {
        GPlayerInfo _soldie = new GPlayerInfo();

        _soldie.MaxAttackNum = 3;

        _soldie.NameID = 100;

        return _soldie;
    }

    public static GPlayerInfo MasterInit()
    {
        GPlayerInfo _master = new GPlayerInfo();

        _master.MaxAttackNum = 5;

        _master.NameID = 101;

        return _master;
    }
}

public interface PlayerType
{

    void Move();

    void Attack();



}



