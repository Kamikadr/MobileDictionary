using SimpleSQL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerRequestDataBaseSqlite : MonoBehaviour
{
    private readonly SQLiteConnection _dbConnection;
    public HandlerRequestDataBaseSqlite(string dataBasePath)
    {
        _dbConnection = new SQLiteConnection(dataBasePath);
    }

    public bool TryGetData<T>(string query, out List<T> data, params object[] ps) where T : new()
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            data = default;
            return false;
        }

        try
        {
            data = _dbConnection.Query<T>(query, ps);
            return true;
        }
        catch (SQLiteException ex)
        {
            Debug.LogError(ex.Message);

            data = default;
            return false;
        }
    }

    public bool CommandSql<T>(string cmdText, out T result)
    {
        if (string.IsNullOrWhiteSpace(cmdText))
        {
            result = default;

            return false;
        }
        try
        {
            SQLiteCommand cmd = _dbConnection.CreateCommand(cmdText);
            result = cmd.ExecuteScalar<T>();
            return true;
        }
        catch (SQLiteException ex)
        {
            Debug.LogError(ex.Message);

            result = default;

            return false;
        }
    }

    public int ExecuteSql(string cmdText, params object[] ps)
    {
        if (string.IsNullOrWhiteSpace(cmdText))
        {
            return default;
        }
        try
        {
            return _dbConnection.Execute(cmdText, ps);
        }
        catch (SQLiteException ex)
        {
            Debug.LogError(ex.Message);

            return default;
        }
    }

    public void Dispose()
    {
        if (_dbConnection != null)
        {
            _dbConnection.Close();
            _dbConnection.Dispose();
        }
    }
}
