using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DBManager : MonoBehaviour
{
    private void Start()
    {
        ReadDatabase();
    }

    void ReadDatabase()
    {
        Debug.Log("Start reading");
        string conn = "URI=file:" + Application.dataPath + "/Plugins/SCORES.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT name, score " + "FROM records";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while(reader.Read())
        {
            Debug.Log("Reading...");

            string name = reader.GetString(0);
            float score = reader.GetFloat(1);

            Debug.Log("name= " + name + " record= " + score);
        }
        Debug.Log("Finish reading");
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
