using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zajecia_PS04.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Zajecia_PS04.DAL
{
    public class UserSQLDB : IUser
    {
        private IConfiguration _configuration;
        string ConnectionString;
        SqlConnection Connection = new SqlConnection();
        public UserSQLDB(IConfiguration _configuration)
        {
            this._configuration = _configuration;
            ConnectionString = _configuration.GetConnectionString("myCompanyDB");
            Connection.ConnectionString = ConnectionString;
        }
        private string HashPassword(SiteUser user)
        {
            PasswordHasher<string> PasswordHasher = new PasswordHasher<string>();
            user.password=PasswordHasher.HashPassword(user.UserName, user.password);
            return user.password;
        }
        public List<SiteUser> List()
        {
            List<SiteUser> UserList = new List<SiteUser>();
            SqlCommand cmd = new SqlCommand("sp_GetUserList",Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                SiteUser NewRecord = new SiteUser
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UserName = Convert.ToString(reader["UserName"]),
                    password = Convert.ToString(reader["Password"])
                };
                UserList.Add(NewRecord);
            }
            Connection.Close();


            return UserList;
        }
        public SiteUser Get(int _id)
        {
            SiteUser TargetUser = new SiteUser();
            SqlCommand cmd = new SqlCommand("sp_GetUser", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter _IdParam = new SqlParameter("@Id", SqlDbType.Int);
            _IdParam.Value = _id;
            cmd.Parameters.Add(_IdParam);
            Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                TargetUser.Id = Convert.ToInt32(reader["Id"]);
                TargetUser.UserName = Convert.ToString(reader["UserName"]);
                TargetUser.password = Convert.ToString(reader["Password"]);
            }
            Connection.Close();
            return TargetUser;
        }
        public int Add(SiteUser _siteuser)
        {
            SqlCommand cmd = new SqlCommand("sp_AddSiteUser", Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter _IdParam = new SqlParameter("@Id", SqlDbType.Int);
            _IdParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_IdParam);

            SqlParameter _UserNameParam = new SqlParameter("@UserName", SqlDbType.NVarChar, 100);
            _UserNameParam.Value = _siteuser.UserName;
            cmd.Parameters.Add(_UserNameParam);

            SqlParameter _PasswordParam = new SqlParameter("@Password", SqlDbType.NVarChar, 260);
            _PasswordParam.Value = HashPassword(_siteuser);
            cmd.Parameters.Add(_PasswordParam);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();

            return 0;
        }
        public int Delete(int _id)
        {
            SqlCommand cmd = new SqlCommand("sp_DeleteUser", Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter _IdParam = new SqlParameter("@Id", SqlDbType.Int);
            _IdParam.Value = _id;
            cmd.Parameters.Add(_IdParam);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();

            return 0;
        }
        public int Update(SiteUser _siteuser)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateUser", Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter _IdParam = new SqlParameter("@Id", SqlDbType.Int);
            _IdParam.Value = _siteuser.Id;
            cmd.Parameters.Add(_IdParam);

            SqlParameter _UserNameParam = new SqlParameter("@UserName", SqlDbType.NVarChar, 100);
            _UserNameParam.Value = _siteuser.UserName;
            cmd.Parameters.Add(_UserNameParam);

            SqlParameter _PasswordParam = new SqlParameter("@Password", SqlDbType.NVarChar, 260);
            _PasswordParam.Value = HashPassword(_siteuser);
            cmd.Parameters.Add(_PasswordParam);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();

            return 0;
        }
    }
}
