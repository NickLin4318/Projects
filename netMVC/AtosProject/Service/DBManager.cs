using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AtosProject.Models;
using Dapper;

namespace AtosProject.Service
{
    public class DBManager
    {
        private readonly string _conn = System.Configuration.ConfigurationManager.ConnectionStrings["_context"].ConnectionString;

        public IEnumerable<Member> GetMembers()
        {
            using (var conn = new SqlConnection(_conn))
            {
                string strSql = "Select * from Member";

                var list = conn.Query<Member>(strSql);

                return list;
            }
        }

        public bool AddMember(Member req)
        {
            using (var conn = new SqlConnection(_conn))
            {
                var sql = "Select * from Member where id=@id";
                DynamicParameters param = new DynamicParameters();
                param.Add("@id", req.Id);

                var target = conn.Query<Member>(sql, param);
                if(target.Count() > 0) { return false; }

                sql = string.Empty;
                sql = "insert into Member(Id, Name, Gender) values(@id, @name, @gender)";
                param.Add("@name", req.Name);
                param.Add("@gender", req.Gender);

                conn.Execute(sql, param);

                return true;
            }
        }
    }
}