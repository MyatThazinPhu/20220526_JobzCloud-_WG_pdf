﻿/*作成者：テテ
 *作成日：20211001
 */
using Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class JC29Jishajouhousettei_Class
    {
        MySqlConnection M_con = new MySqlConnection("Server=" + DBUtilitycs.Server + "; Database=" + DBUtilitycs.Database + "; User Id=" + DBUtilitycs.user + "; password=" + DBUtilitycs.pass);

        public string loginId { get; set; }

        public void ReadConn()

        //MySqlConnection con = new MySqlConnection("Server=" + DBUtilitycs.Server + "; Database=" + DBUtilitycs.Database + "; User Id=" + DBUtilitycs.user + "; password=" + DBUtilitycs.pass);
        public DataTable HyoujiData(string sqlstring)
        {
            ReadConn();
            DataTable dt = new DataTable();
            using (MySqlDataAdapter adap = new MySqlDataAdapter(sqlstring, con))
            {
                adap.Fill(dt);
            }
            return dt;
        }

        public bool infoSave(string sqlStr)
        {
            ReadConn();
            int retval = 0;
            bool fret = false;
            MySqlCommand myCommand = new MySqlCommand(sqlStr, con);
            con.Open();
            retval = myCommand.ExecuteNonQuery();
            con.Close();
            if (retval == -1)
            {
                fret = false;
            }
            else
            {
                fret = true;
            }
            return fret;
        }
        public void infoUpdate(string sqlStr)
        {
            ReadConn();
            MySqlCommand myCommand = new MySqlCommand(sqlStr, con);
            con.Open();
            myCommand.ExecuteNonQuery();
            con.Close();

            //return fret;
        }
    }
}