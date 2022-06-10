using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DBManager : MonoBehaviour
{
    private void Start()
    {
        //ReadDatabase();
    }

    void ReadDatabase()
    {
        Debug.Log("Start reading");
        string conn = "URI=file:" + Application.dataPath + "/Plugins/saves.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT checkpoint " + "FROM file";
        dbcmd.CommandText = sqlQuery;

        IDataReader reader = dbcmd.ExecuteReader();
        while(reader.Read())
        {
            Debug.Log("Reading...");

            string name = reader.GetString(0);

            Debug.Log("name= " + name);
        }

        Debug.Log("Finish reading");
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public static void ReadFile(int idFile)
    {
        //Debug.Log("Start reading");
        string conn = "URI=file:" + Application.dataPath + "/Plugins/saves.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT checkpoint, Fruta1, Fruta2, Fruta3, Fruta4, Fruta5, Fruta6, Fruta7 " + "FROM file " + "WHERE id = '"+ idFile +"'";
        dbcmd.CommandText = sqlQuery;

        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            //Debug.Log("Reading...");

            string name = reader.GetString(0);
            int fruta1 = reader.GetInt32(1);
            int fruta2 = reader.GetInt32(2);
            int fruta3 = reader.GetInt32(3);
            int fruta4 = reader.GetInt32(4);
            int fruta5 = reader.GetInt32(5);
            int fruta6 = reader.GetInt32(6);
            int fruta7 = reader.GetInt32(7);

            Debug.Log("name= " + fruta1);

            StateDataController.checkpoint = name;
            StateDataController.isFruitEaten_1 = fruta1 > 0;
            StateDataController.isFruitEaten_2 = fruta2 > 0;
            StateDataController.isFruitEaten_3 = fruta3 > 0;
            StateDataController.isFruitEaten_4 = fruta4 > 0;
            StateDataController.isFruitEaten_5 = fruta5 > 0;
            StateDataController.isFruitEaten_6 = fruta6 > 0;
            StateDataController.isFruitEaten_7 = fruta7 > 0;
        }

        //Debug.Log("Finish reading");
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public static void SaveCheckpointDB(int idFile)
    {
        //Debug.Log("Start reading");
        string conn = "URI=file:" + Application.dataPath + "/Plugins/saves.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "UPDATE file SET checkpoint = '" + StateDataController.checkpoint + "'" + " WHERE id = '" + idFile + "'";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        Debug.Log("Finish saving checkpoint");
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public static void SaveFruitstDB(int idFile)
    {
        //Debug.Log("Start reading");
        string conn = "URI=file:" + Application.dataPath + "/Plugins/saves.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "UPDATE file SET Fruta1 = '" + (StateDataController.isFruitEaten_1 ? 1 : 0) + "'" +
                                        ", Fruta2 = '" + (StateDataController.isFruitEaten_2 ? 1 : 0) + "'" +
                                        ", Fruta3 = '" + (StateDataController.isFruitEaten_3 ? 1 : 0) + "'" +
                                        ", Fruta4 = '" + (StateDataController.isFruitEaten_4 ? 1 : 0) + "'" +
                                        ", Fruta5 = '" + (StateDataController.isFruitEaten_5 ? 1 : 0) + "'" +
                                        ", Fruta6 = '" + (StateDataController.isFruitEaten_6 ? 1 : 0) + "'" +
                                        ", Fruta7 = '" + (StateDataController.isFruitEaten_7 ? 1 : 0) + "'" + " WHERE id = '" + idFile + "'";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        Debug.Log("Finish saving fruits");
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
