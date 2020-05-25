using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XyzTime
{
    class WebConnect
    {

        public DataSet GetUserData(string str_Email, string str_Password)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            AWebTime.UserInfo UInfo = new AWebTime.UserInfo();
            string str_Xml = UInfo.GetUserInfoV3(str_Email, str_Password);
            DataSet ds = new DataSet();
            System.IO.StringReader SR = new System.IO.StringReader(str_Xml);
            ds.ReadXml(SR);
            return ds;
        }

        public string GetDashboardToken(string str_UserToken)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            AWebTime.UserInfo UInfo = new AWebTime.UserInfo();
            string str_Xml = UInfo.GetDashboardToken(str_UserToken);
            DataSet ds = new DataSet();
            System.IO.StringReader SR = new System.IO.StringReader(str_Xml);
            ds.ReadXml(SR);
            return ds.Tables[0].Rows[0]["DashToken"].ToString();
        }
    }
}
