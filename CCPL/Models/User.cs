using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CCPL.Models;
using System.Data;

namespace CCPL.Models
{
    public class UserDetails
    {
        public int code { set; get; }
        public string userID { set; get; }
        public string password { set; get; }
        public string groupId { set; get; }
        public string name { set; get; }
        public string designation { set; get; }
        public string department { set; get; }
        public string lastLogin { set; get; }
        public string loginFlag { set; get; }
        public string status{ set; get; }
        public string empCode { set; get; }
        public string userType { set; get; }
    }
    public class User
    {
        
        public int ValidateUser(string userID, string Password)
        {
            try
            {
                DBHelper dbh = new DBHelper();
                DataTable dtUser = new DataTable();
                string strQuery = "";
                strQuery = "SELECT Code,um_user_id,um_passwd,um_group_id,um_user_name,um_designation,um_dept,um_lastlogin,";
                strQuery += "um_loginflag,um_status,um_usertype,um_empcode ";
                strQuery += " FROM User_master Where um_user_id='" + userID + "'";
                dtUser = dbh.executeQuery(strQuery);
                if (dtUser.Rows.Count > 0)
                {
                    DataRow drUser = dtUser.Rows[0];
                    if ( drUser["um_passwd"].ToString().Trim() == Password.Trim())
                    {
                        //Login Success
                        UserDetails userObj = new UserDetails();
                        userObj.code = Convert.ToInt32(drUser["code"]);
                        userObj.userID = drUser["um_user_id"].ToString().Trim();
                        userObj.password = drUser["um_passwd"].ToString().Trim();
                        userObj.groupId = drUser["um_group_id"].ToString().Trim();
                        userObj.designation = drUser["um_designation"].ToString().Trim();
                        userObj.name = drUser["um_user_name"].ToString().Trim();
                        userObj.department = drUser["um_dept"].ToString().Trim();
                        userObj.lastLogin = drUser["um_lastlogin"].ToString().Trim();
                        userObj.loginFlag = drUser["um_loginflag"].ToString().Trim();
                        userObj.status = drUser["um_status"].ToString().Trim();
                        userObj.userType = drUser["um_usertype"].ToString().Trim();
                        userObj.empCode = drUser["um_empcode"].ToString().Trim();
                    }
                    else
                    {
                        //Wrong Password
                    }
                }
                else
                {
                    // Wrong User name
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
                
        }
        public void UpdateUserStatus(string userCode, string Status)
        {
            DBHelper dbh = new DBHelper();
            dbh.executeNonQuery("Update user_master set um_loginflag = " + Status.ToString() + " where code = " + userCode.ToString());
        }
    }
}