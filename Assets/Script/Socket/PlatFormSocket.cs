using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LWSocket
{
    class PlatFormSocket:SocketTest
    {

        private static PlatFormSocket instance = null;

        public static PlatFormSocket Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlatFormSocket();
                }

                return instance;
            }
        }
        public void ReLogin(string accout,string password)
        {
            string str = ProtocalID.Login_Main+"|"+ ProtocalID.Login_Ass + "|" +accout+"|"+ password;

           // str.Split(new char[] { '|' }, 3);

            Debug.Log(string.Format("请求登录 账号:{0} 密码:{1}",accout,password));
            SendDate(str);

        }
        public void ReRegiste(string accout, string password)
        {
            string str = ProtocalID.Registe_Main + "|" + ProtocalID.Registe_Ass + "|" + accout + "|" + password;

            // str.Split(new char[] { '|' }, 3);

            Debug.Log(string.Format("请求注册 账号:{0} 密码:{1}", accout, password));
            SendDate(str);

        }
    }
}
