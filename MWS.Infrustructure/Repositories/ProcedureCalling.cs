using Dapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace MWS.Repository
{
    public class ObjectParameter
    {
        public ObjectParameter(string name, object value)
        {
            this.Name = name;
            this.Value = value;
            if (value != null)
            {
                this.ParameterType = value.GetType();
            }
            else
            {
                this.ParameterType = typeof(string);
            }
        }
        public ObjectParameter(string name, Type parameterType)
        {
            this.Name = name;


            this.ParameterType = parameterType;

        }
        public Type ParameterType { get; set; }
        public object Value { get; set; }
        public string Name { get; set; }
    }

    public interface IProcedureCalling
    {

        int ExecuteNonQuery(string query, params ObjectParameter[] sqlParams);
        Task<int> ExecuteNonQueryAsync(string query, params ObjectParameter[] sqlParams);
        int ExecuteDapperNonQuery(string query, object Params);

        Task<int> ExecuteDapperNonQueryAsync(string query, object Params);

        IEnumerable<T> ExecuteQueryWithDapperRet<T>(string query, object Params) where T : class, new();
        Task<IEnumerable<T>> ExecuteQueryWithDapperRetAsync<T>(string query, object Params) where T : class, new();

        T ExecuteQuerySingleOrDefault<T>(string query, object Params) where T : class, new();
        Task<T> ExecuteQuerySingleOrDefaultAsync<T>(string query, object Params) where T : class, new();
        T ExecuteQuerySingle<T>(string query, object Params);

        Task<T> ExecuteQuerySingleAsync<T>(string query, object Params);

        IEnumerable<T> ExecuteProcedureRetOracle<T>(string procedureCommand, string outputParam, params ObjectParameter[] sqlParams) where T : class, new();
        Task<IEnumerable<T>> ExecuteProcedureRetOracleAsync<T>(string procedureCommand, string outputParam, params ObjectParameter[] sqlParams) where T : class, new();

        IEnumerable<T> ExecuteProcedureAndGetResults<T>(string procedureCommand, params ObjectParameter[] sqlParams) where T : class, new();
        Task<IEnumerable<T>> ExecuteProcedureAndGetResultsAsync<T>(string procedureCommand, params ObjectParameter[] sqlParams) where T : class, new();

        int ExecuteProcedure(string name, params ObjectParameter[] parameters);
        Task<int> ExecuteProcedureAsync(string name, params ObjectParameter[] parameters);



    }


    public class ProcedureCalling : IProcedureCalling
    {

        private readonly string connectionString;
        private readonly string Provider;

        private readonly Dictionary<string, object> cache;
        public ProcedureCalling(IConfiguration configuration, string connName = "MCMSDB")
        {

            this.connectionString = configuration["ConnectionStrings:" + connName];
            this.Provider = configuration["ConnectionStrings:" + connName + "_PROVIDER"];
            this.fillDictionary();
            this.cache = new Dictionary<string, object>();
        }


        public ProcedureCalling(string provider, string connectionString)
        {

            this.connectionString = connectionString;
            this.Provider = provider;
            this.fillDictionary();
        }

        public async Task<IEnumerable<T>> ExecuteProcedureRetOracleAsync<T>(string procedureCommand, string outputParam, params ObjectParameter[] sqlParams) where T : class, new()
        {
            List<T> ret = new List<T>();
            DbProviderFactory factory =
                   DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                await conn.OpenAsync();

                try
                {

                    DbCommand command = conn.CreateCommand();

                    List<DbParameter> newParams = new List<DbParameter>();
                    foreach (var o in sqlParams)
                    {
                        DbType type = DbType.String;
                        if (typeMap.ContainsKey(o.ParameterType))
                            type = typeMap[o.ParameterType];

                        DbParameter prm = command.CreateParameter();
                        prm.DbType = type;
                        prm.Direction = ParameterDirection.InputOutput;
                        prm.ParameterName = o.Name;
                        prm.Value = o.Value;
                        newParams.Add(prm);
                    }

                    OracleParameter outPut = new OracleParameter(outputParam, OracleDbType.RefCursor);

                    command.Parameters.AddRange(newParams.ToArray());

                    command.Parameters.Add(outPut);

                    command.CommandText = procedureCommand;
                    command.CommandType = CommandType.StoredProcedure;
                    //LogProcedure(procedureCommand, true, sqlParams);
                    await command.ExecuteNonQueryAsync();

                    OracleDataReader datareader = ((OracleRefCursor)outPut.Value).GetDataReader();

                    T[] retArr = await readDataReaderToObjectAsync<T>(datareader);
                    ret = retArr.ToList();

                    //LogProcedure(procedureCommand, false, sqlParams);
                }
                catch (Exception executeError)
                {
                    foundEx = executeError;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        await conn.CloseAsync();
                }

            }
            if (foundEx != null)
                throw foundEx;

            return ret;
        }

        public IEnumerable<T> ExecuteProcedureRetOracle<T>(string procedureCommand, string outputParam, params ObjectParameter[] sqlParams) where T : class, new()
        {
            List<T> ret = new List<T>();
            DbProviderFactory factory =
                   DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                conn.Open();

                try
                {

                    DbCommand command = conn.CreateCommand();

                    List<DbParameter> newParams = new List<DbParameter>();
                    foreach (var o in sqlParams)
                    {
                        DbType type = DbType.String;
                        if (typeMap.ContainsKey(o.ParameterType))
                            type = typeMap[o.ParameterType];

                        DbParameter prm = command.CreateParameter();
                        prm.DbType = type;
                        prm.Direction = ParameterDirection.InputOutput;
                        prm.ParameterName = o.Name;
                        prm.Value = o.Value;
                        newParams.Add(prm);
                    }

                    OracleParameter outPut = new OracleParameter(outputParam, OracleDbType.RefCursor);

                    command.Parameters.AddRange(newParams.ToArray());

                    command.Parameters.Add(outPut);

                    command.CommandText = procedureCommand;
                    command.CommandType = CommandType.StoredProcedure;
                    //LogProcedure(procedureCommand, true, sqlParams);
                    command.ExecuteNonQuery();

                    OracleDataReader datareader = ((OracleRefCursor)outPut.Value).GetDataReader();

                    T[] retArr = readDataReaderToObject<T>(datareader);
                    ret = retArr.ToList();

                    //LogProcedure(procedureCommand, false, sqlParams);
                }
                catch (Exception executeError)
                {
                    foundEx = executeError;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }

            }
            if (foundEx != null)
                throw foundEx;

            return ret;
        }

        public IEnumerable<T> ExecuteProcedureAndGetResults<T>(string procedureCommand, params ObjectParameter[] sqlParams) where T : class, new()
        {
            IEnumerable<T> ret = new T[0];
            DbProviderFactory factory = DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                conn.Open();

                try
                {
                    DbCommand command = conn.CreateCommand();

                    List<DbParameter> newParams = new List<DbParameter>();
                    foreach (var o in sqlParams)
                    {
                        DbType type = DbType.String;
                        if (typeMap.ContainsKey(o.ParameterType))
                            type = typeMap[o.ParameterType];

                        DbParameter prm = command.CreateParameter();
                        prm.DbType = type;
                        prm.Direction = ParameterDirection.InputOutput;
                        prm.ParameterName = o.Name;
                        prm.Value = o.Value;
                        newParams.Add(prm);
                    }

                    command.Parameters.AddRange(newParams.ToArray());

                    command.CommandText = procedureCommand;
                    command.CommandType = CommandType.StoredProcedure;
                    //LogProcedure(procedureCommand, true, sqlParams);

                    DbDataReader datareader = command.ExecuteReader();
                    T[] retArr = readDataReaderToObject<T>(datareader);
                    ret = retArr;

                    // LogProcedure(procedureCommand, false, sqlParams);
                }
                catch (Exception executeError)
                {
                    foundEx = executeError;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }

            }
            if (foundEx != null)
                throw foundEx;

            return ret;
        }

        public async Task<IEnumerable<T>> ExecuteProcedureAndGetResultsAsync<T>(string procedureCommand, params ObjectParameter[] sqlParams) where T : class, new()
        {
            IEnumerable<T> ret = new T[0];
            DbProviderFactory factory = DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                await conn.OpenAsync();

                try
                {
                    DbCommand command = conn.CreateCommand();

                    List<DbParameter> newParams = new List<DbParameter>();
                    foreach (var o in sqlParams)
                    {
                        DbType type = DbType.String;
                        if (typeMap.ContainsKey(o.ParameterType))
                            type = typeMap[o.ParameterType];

                        DbParameter prm = command.CreateParameter();
                        prm.DbType = type;
                        prm.Direction = ParameterDirection.InputOutput;
                        prm.ParameterName = o.Name;
                        prm.Value = o.Value;
                        newParams.Add(prm);
                    }

                    command.Parameters.AddRange(newParams.ToArray());

                    command.CommandText = procedureCommand;
                    command.CommandType = CommandType.StoredProcedure;
                    //LogProcedure(procedureCommand, true, sqlParams);

                    DbDataReader datareader = await command.ExecuteReaderAsync();
                    T[] retArr = await readDataReaderToObjectAsync<T>(datareader);
                    ret = retArr;

                    // LogProcedure(procedureCommand, false, sqlParams);
                }
                catch (Exception executeError)
                {
                    foundEx = executeError;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        await conn.CloseAsync();
                }

            }
            if (foundEx != null)
                throw foundEx;

            return ret;
        }

        public int ExecuteProcedure(string name, params ObjectParameter[] parameters)
        {
            int ret = -1;
            DbProviderFactory factory =
                   DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                conn.Open();

                try
                {
                    DbCommand command = conn.CreateCommand();

                    List<DbParameter> newParams = new List<DbParameter>();
                    foreach (var o in parameters)
                    {
                        DbType type = DbType.String;
                        if (typeMap.ContainsKey(o.ParameterType))
                            type = typeMap[o.ParameterType];

                        DbParameter prm = command.CreateParameter();
                        prm.DbType = type;
                        prm.Direction = ParameterDirection.InputOutput;
                        prm.ParameterName = o.Name;
                        prm.Value = o.Value;
                        if (prm.DbType == DbType.String && prm.Value != null && prm.Value.ToString().Length > 4000)
                        {
                            prm = createOracleParameterWithNCLob(prm);
                        }
                        newParams.Add(prm);
                    }

                    command.Parameters.AddRange(newParams.ToArray());
                    command.CommandText = name;
                    command.CommandType = CommandType.StoredProcedure;
                    //LogProcedure(name, true, parameters);
                    ret = command.ExecuteNonQuery();

                    foreach (var o in parameters)
                    {
                        foreach (var np in newParams)
                        {
                            if (np.ParameterName == o.Name)
                            {
                                try
                                {
                                    o.Value = np.Value;
                                }
                                catch
                                {

                                }
                                break;
                            }
                        }
                    }
                    //LogProcedure(name, false, parameters);

                }
                catch (Exception executeError)
                {
                    foundEx = executeError;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }

            }
            if (foundEx != null)
                throw foundEx;

            return ret;
        }

        public async Task<int> ExecuteProcedureAsync(string name, params ObjectParameter[] parameters)
        {
            int ret = -1;
            DbProviderFactory factory =
                   DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                await conn.OpenAsync();

                try
                {
                    DbCommand command = conn.CreateCommand();

                    List<DbParameter> newParams = new List<DbParameter>();
                    foreach (var o in parameters)
                    {
                        DbType type = DbType.String;
                        if (typeMap.ContainsKey(o.ParameterType))
                            type = typeMap[o.ParameterType];

                        DbParameter prm = command.CreateParameter();
                        prm.DbType = type;
                        prm.Direction = ParameterDirection.InputOutput;
                        prm.ParameterName = o.Name;
                        prm.Value = o.Value;
                        if(prm.DbType == DbType.String && prm.Value != null && prm.Value.ToString().Length > 4000)
                        {
                            prm = createOracleParameterWithNCLob(prm);
                        }
                        newParams.Add(prm);
                    }

                    command.Parameters.AddRange(newParams.ToArray());
                    command.CommandText = name;
                    command.CommandType = CommandType.StoredProcedure;
                    //LogProcedure(name, true, parameters);
                    ret = await command.ExecuteNonQueryAsync();

                    foreach (var o in parameters)
                    {
                        foreach (var np in newParams)
                        {
                            if (np.ParameterName == o.Name)
                            {
                                try
                                {
                                    o.Value = np.Value;
                                }
                                catch
                                {

                                }
                                break;
                            }
                        }
                    }
                    //LogProcedure(name, false, parameters);

                }
                catch (Exception executeError)
                {
                    foundEx = executeError;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        await conn.CloseAsync();
                }

            }
            if (foundEx != null)
                throw foundEx;

            return ret;
        }

        private DbParameter createOracleParameterWithNCLob(DbParameter prm)
        {
            if (!this.Provider.ToLower().Contains("oracle"))
            {
                return prm;
            }
            Oracle.ManagedDataAccess.Client.OracleParameter newParam = new OracleParameter(prm.ParameterName, Oracle.ManagedDataAccess.Client.OracleDbType.NClob);
            newParam.Value = prm.Value;
            return newParam;
        }

        public int ExecuteDapperNonQuery(string query, object Params)
        {
            DbProviderFactory factory =
                   DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                conn.Open();

                try
                {

                    int ret = conn.Execute(query, Params);
                    return ret;



                }
                catch (Exception executeError)
                {
                    foundEx = executeError;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }

            }

            throw foundEx;

        }

        public async Task<int> ExecuteDapperNonQueryAsync(string query, object Params)
        {
            DbProviderFactory factory =
                   DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                await conn.OpenAsync();

                try
                {

                    int ret = await conn.ExecuteAsync(query, Params);
                    return ret;



                }
                catch (Exception executeError)
                {
                    foundEx = executeError;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        await conn.CloseAsync();
                }

            }

            throw foundEx;

        }

        public int ExecuteNonQuery(string query, params ObjectParameter[] sqlParams)
        {

            DbProviderFactory factory =
                   DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                conn.Open();

                try
                {

                    DbCommand command = conn.CreateCommand();

                    List<DbParameter> newParams = new List<DbParameter>();
                    foreach (var o in sqlParams)
                    {
                        DbType type = DbType.String;
                        if (typeMap.ContainsKey(o.ParameterType))
                            type = typeMap[o.ParameterType];

                        DbParameter prm = command.CreateParameter();
                        prm.DbType = type;
                        prm.Direction = ParameterDirection.InputOutput;
                        prm.ParameterName = o.Name;
                        prm.Value = o.Value;
                        newParams.Add(prm);
                    }


                    command.Parameters.AddRange(newParams.ToArray());

                    command.CommandText = query;
                    command.CommandType = CommandType.Text;

                    int ret = command.ExecuteNonQuery();
                    var testMode = System.Configuration.ConfigurationManager.AppSettings["TestMode"];
                    if (!string.IsNullOrWhiteSpace(testMode) && testMode.ToLower().Trim() == "true")
                    {
                        string logText = "EXECUTED Query : " + (query ?? "") + " returned affected rows : " + ret;
                        //Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(new System.ApplicationException(logText), System.Web.HttpContext.Current));

                    }
                    return ret;

                }
                catch (Exception executeError)
                {
                    foundEx = executeError;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }

            }

            throw foundEx;

        }

        public async Task<int> ExecuteNonQueryAsync(string query, params ObjectParameter[] sqlParams)
        {

            DbProviderFactory factory =
                   DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                await conn.OpenAsync();

                try
                {

                    DbCommand command = conn.CreateCommand();

                    List<DbParameter> newParams = new List<DbParameter>();
                    foreach (var o in sqlParams)
                    {
                        DbType type = DbType.String;
                        if (typeMap.ContainsKey(o.ParameterType))
                            type = typeMap[o.ParameterType];

                        DbParameter prm = command.CreateParameter();
                        prm.DbType = type;
                        prm.Direction = ParameterDirection.InputOutput;
                        prm.ParameterName = o.Name;
                        prm.Value = o.Value;
                        newParams.Add(prm);
                    }


                    command.Parameters.AddRange(newParams.ToArray());

                    command.CommandText = query;
                    command.CommandType = CommandType.Text;

                    int ret = await command.ExecuteNonQueryAsync();

                    return ret;

                }
                catch (Exception executeError)
                {
                    foundEx = executeError;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        await conn.CloseAsync();
                }

            }

            throw foundEx;

        }


        public IEnumerable<T> ExecuteQueryRet<T>(string query, params ObjectParameter[] sqlParams) where T : class, new()
        {
            T[] ret = new T[0];

            DbProviderFactory factory =
                   DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                conn.Open();

                try
                {

                    DbCommand command = conn.CreateCommand();

                    List<DbParameter> newParams = new List<DbParameter>();
                    foreach (var o in sqlParams)
                    {
                        DbType type = DbType.String;
                        if (typeMap.ContainsKey(o.ParameterType))
                            type = typeMap[o.ParameterType];

                        DbParameter prm = command.CreateParameter();
                        prm.DbType = type;
                        prm.Direction = ParameterDirection.InputOutput;
                        prm.ParameterName = o.Name;
                        prm.Value = o.Value;
                        newParams.Add(prm);
                    }


                    command.Parameters.AddRange(newParams.ToArray());

                    command.CommandText = query;
                    command.CommandType = CommandType.Text;

                    DbDataReader datareader = command.ExecuteReader();
                    T[] retArr = readDataReaderToObject<T>(datareader);
                    ret = retArr;
                    return ret;
                }
                catch (Exception executeError)
                {
                    foundEx = executeError;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }

            }

            throw foundEx;

        }

        private static T[] readDataReaderToObject<T>(DbDataReader datareader) where T : class, new()
        {
            var props = typeof(T).GetProperties();
            JArray jArr = new JArray();
            List<string> lstNames = new List<string>();
            while (datareader.Read())
            {
                //T t = new T();
                JObject jObj = new JObject();
                jArr.Add(jObj);

                if (lstNames.Count == 0)
                {
                    foreach (PropertyInfo prop in props)
                    {

                        try
                        {
                            string propName = prop.Name;

                            if (datareader[propName] != DBNull.Value)
                            {


                            }
                            lstNames.Add(propName);

                        }
                        catch
                        {

                        }
                    }
                }

                foreach (var propName in lstNames)
                {
                    try
                    {
                        if (datareader[propName] != DBNull.Value)
                        {
                            jObj[propName] = JToken.FromObject(datareader[propName]);
                        }
                    }
                    catch
                    {

                    }
                }



            }

            T[] retArr = JsonConvert.DeserializeObject<T[]>(jArr.ToString());
            return retArr;
        }

        private static async Task<T[]> readDataReaderToObjectAsync<T>(DbDataReader datareader) where T : class, new()
        {
            var props = typeof(T).GetProperties();
            JArray jArr = new JArray();
            List<string> lstNames = new List<string>();
            bool readCheck = await datareader.ReadAsync();
            while (readCheck)
            {

                //T t = new T();
                JObject jObj = new JObject();
                jArr.Add(jObj);

                if (lstNames.Count == 0)
                {
                    foreach (PropertyInfo prop in props)
                    {

                        try
                        {
                            string propName = prop.Name;

                            if (datareader[propName] != DBNull.Value)
                            {


                            }
                            lstNames.Add(propName);

                        }
                        catch
                        {

                        }
                    }
                }

                foreach (var propName in lstNames)
                {
                    try
                    {
                        if (datareader[propName] != DBNull.Value)
                        {
                            jObj[propName] = JToken.FromObject(datareader[propName]);
                        }
                    }
                    catch
                    {

                    }
                }


                readCheck = await datareader.ReadAsync();
            }

            T[] retArr = JsonConvert.DeserializeObject<T[]>(jArr.ToString());
            return retArr;
        }

        #region private

        private Dictionary<Type, DbType> typeMap = new Dictionary<Type, DbType>();

        private Dictionary<Type, DbType> fillDictionary()
        {
            typeMap = new Dictionary<Type, DbType>();
            typeMap[typeof(byte)] = DbType.Byte;
            typeMap[typeof(sbyte)] = DbType.SByte;
            typeMap[typeof(short)] = DbType.Int16;
            typeMap[typeof(ushort)] = DbType.UInt16;
            typeMap[typeof(int)] = DbType.Int32;
            typeMap[typeof(uint)] = DbType.UInt32;
            typeMap[typeof(long)] = DbType.Int64;
            typeMap[typeof(ulong)] = DbType.UInt64;
            typeMap[typeof(float)] = DbType.Single;
            typeMap[typeof(double)] = DbType.Double;
            typeMap[typeof(decimal)] = DbType.Decimal;
            typeMap[typeof(bool)] = DbType.Boolean;
            typeMap[typeof(string)] = DbType.String;
            typeMap[typeof(char)] = DbType.StringFixedLength;
            typeMap[typeof(Guid)] = DbType.Guid;
            typeMap[typeof(DateTime)] = DbType.DateTime;
            typeMap[typeof(DateTimeOffset)] = DbType.DateTimeOffset;
            typeMap[typeof(byte[])] = DbType.Binary;
            typeMap[typeof(byte?)] = DbType.Byte;
            typeMap[typeof(sbyte?)] = DbType.SByte;
            typeMap[typeof(short?)] = DbType.Int16;
            typeMap[typeof(ushort?)] = DbType.UInt16;
            typeMap[typeof(int?)] = DbType.Int32;
            typeMap[typeof(uint?)] = DbType.UInt32;
            typeMap[typeof(long?)] = DbType.Int64;
            typeMap[typeof(ulong?)] = DbType.UInt64;
            typeMap[typeof(float?)] = DbType.Single;
            typeMap[typeof(double?)] = DbType.Double;
            typeMap[typeof(decimal?)] = DbType.Decimal;
            typeMap[typeof(bool?)] = DbType.Boolean;
            typeMap[typeof(char?)] = DbType.StringFixedLength;
            typeMap[typeof(Guid?)] = DbType.Guid;
            typeMap[typeof(DateTime?)] = DbType.DateTime;
            typeMap[typeof(DateTimeOffset?)] = DbType.DateTimeOffset;

            return typeMap;
        }

        #endregion

        public IEnumerable<T> ExecuteQueryWithDapperRet<T>(string query, object Params) where T : class, new()
        {

            DbProviderFactory factory =
                   DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = this.connectionString;
                    conn.Open();
                    return conn.Query<T>(query, Params);
                }
                catch (Exception ex)
                {
                    foundEx = ex;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }

            }

            throw foundEx;

        }

        public async Task<IEnumerable<T>> ExecuteQueryWithDapperRetAsync<T>(string query, object Params) where T : class, new()
        {
            DbProviderFactory factory =
                     DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = this.connectionString;
                    await conn.OpenAsync();
                    return await conn.QueryAsync<T>(query, Params);
                }
                catch (Exception ex)
                {
                    foundEx = ex;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        await conn.CloseAsync();
                }
            }

            throw foundEx;



        }

        public async Task<T> ExecuteQuerySingleOrDefaultAsync<T>(string query, object Params) where T : class, new()
        {
            DbProviderFactory factory =
                      DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = this.connectionString;
                    await conn.OpenAsync();
                    return await conn.QuerySingleOrDefaultAsync<T>(query, Params);
                }
                catch (Exception ex)
                {
                    foundEx = ex;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        await conn.CloseAsync();
                }
            }

            throw foundEx;

        }
        public T ExecuteQuerySingleOrDefault<T>(string query, object Params) where T : class, new()
        {
            DbProviderFactory factory =
                       DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = this.connectionString;
                    conn.Open();
                    return conn.QuerySingleOrDefault<T>(query, Params);
                }
                catch (Exception ex)
                {
                    foundEx = ex;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }
            }

            throw foundEx;

        }

        public T ExecuteQuerySingle<T>(string query, object Params)
        {
            DbProviderFactory factory =
                       DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = this.connectionString;
                    conn.Open();
                    return conn.QuerySingle<T>(query, Params);
                }
                catch (Exception ex)
                {
                    foundEx = ex;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }
            }

            throw foundEx;

        }

        public async Task<T> ExecuteQuerySingleAsync<T>(string query, object Params)
        {
            DbProviderFactory factory =
                       DbProviderFactories.GetFactory(this.Provider);

            Exception foundEx = null;

            using (var conn = factory.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = this.connectionString;
                    await conn.OpenAsync();
                    return await conn.QuerySingleAsync<T>(query, Params);
                }
                catch (Exception ex)
                {
                    foundEx = ex;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        await conn.CloseAsync();
                }
            }

            throw foundEx;

        }

    }

    public interface IProcedureCallingFactory
    {
        IProcedureCalling Create(string provider, string connectionString);

    }

    public class ProcedureCallingFactory
        : IProcedureCallingFactory
    {
        public IProcedureCalling Create(string provider, string connectionString)
        {
            return new ProcedureCalling(provider, connectionString);
        }
    }

}
