﻿
namespace HotelAppLibrary.Database
{
    public interface ISqlDataAcess
    {
        List<T> LoadData<T, U>(string sqlStatement,
                               U parameters,
                               string connectionStringName,
                               bool isStoredProcedure = false);
        void SaveData<T>(string sqlStatement,
                         T parameters,
                         string connectionStringName,
                         bool isStoredProcedure = false);
    }
}