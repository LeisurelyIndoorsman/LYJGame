using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LyjTools  {

    private static LyjTools _instance;

    public static LyjTools Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LyjTools();
            }
            return _instance;
        }

        set
        {
            _instance = value;
        }


    }

    public  object BytesToStuct(byte[] bytes, Type type)
    {
        //得到结构体的大小
        int size = Marshal.SizeOf(type);
        //byte数组长度小于结构体的大小
        if (size > bytes.Length)
        {
            //返回空
            return null;
        }
        //分配结构体大小的内存空间
        IntPtr structPtr = Marshal.AllocHGlobal(size);
        //将byte数组拷到分配好的内存空间
        Marshal.Copy(bytes, 0, structPtr, size);
        //将内存空间转换为目标结构体
        object obj = Marshal.PtrToStructure(structPtr, type);
        //释放内存空间
        Marshal.FreeHGlobal(structPtr);
        //返回结构体
        return obj;
    }
}
