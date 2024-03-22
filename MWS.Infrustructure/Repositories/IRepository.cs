using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using MWS.Repository;
using System.Linq.Expressions;

namespace MWS.Infrustructure.Repositories
{
    public interface IRepository
    {
        DbContext context { get; }
        IProcedureCalling procCalling { get; }



        DbSet<TEntity> Set<TEntity>()
                where TEntity : class;



        /// <summary>
        /// Gets all objects from database
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll<T>() where T : class;

        void Attach<T>(T t) where T : class;


        void Deattach<T>(T t) where T : class;

        /// <summary>
        /// Gets objects from database by filter.
        /// </summary>
        /// <param name="predicate">Specified a filter</param>
        /// <returns></returns>
        IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class;








        /// <summary>
        /// Find object by specified expression.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Find<T>(Expression<Func<T, bool>> predicate) where T : class;

        Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class;


        T Create<T>(T t) where T : class;
        T Update<T>(T t) where T : class;

        Task<T> CreateAsync<T>(T t) where T : class;


        EntityEntry<T> Delete<T>(T t) where T : class;



        int SaveChanges();
        Task<int> SaveChangesAsync();








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

    public class Repository : IRepository
    {
        DbContext _context;
        IProcedureCalling _procCalling;
        public Repository(DbContext context, IProcedureCalling procCalling)
        {
            this._context = context;
            this._procCalling = procCalling;
        }

        public DbContext context
        {
            get
            {
                return _context;
            }
        }

        public IProcedureCalling procCalling
        {
            get
            {
                return this._procCalling;
            }
        }

        public void Attach<T>(T t) where T : class
        {
            this.context.Attach(t);
        }

        public T Create<T>(T t) where T : class
        {
            this.Set<T>().Add(t); ;
            return t;
        }
        public T Update<T>(T t) where T : class
        {
            this.Set<T>().Update(t);
            return t;
        }
        public async Task<T> CreateAsync<T>(T t) where T : class
        {
            await this.Set<T>().AddAsync(t);
            return t;
        }

        public void Deattach<T>(T t) where T : class
        {
            this.context.Entry(t).State = EntityState.Detached;
        }

        public EntityEntry<T> Delete<T>(T t) where T : class
        {
            return this.Set<T>().Remove(t);

        }

        public int ExecuteDapperNonQuery(string query, object Params)
        {
            return this.procCalling.ExecuteDapperNonQuery(query, Params);
        }

        public async Task<int> ExecuteDapperNonQueryAsync(string query, object Params)
        {
            return await this.procCalling.ExecuteDapperNonQueryAsync(query, Params);
        }

        public int ExecuteNonQuery(string query, params ObjectParameter[] sqlParams)
        {
            return this.ExecuteNonQuery(query, sqlParams);
        }

        public async Task<int> ExecuteNonQueryAsync(string query, params ObjectParameter[] sqlParams)
        {
            return await this.ExecuteNonQueryAsync(query, sqlParams);
        }

        public int ExecuteProcedure(string name, params ObjectParameter[] parameters)
        {
            return this.ExecuteProcedure(name, parameters);
        }

        public IEnumerable<T> ExecuteProcedureAndGetResults<T>(string procedureCommand, params ObjectParameter[] sqlParams) where T : class, new()
        {
            return this.ExecuteProcedureAndGetResults<T>(procedureCommand, sqlParams);
        }

        public async Task<IEnumerable<T>> ExecuteProcedureAndGetResultsAsync<T>(string procedureCommand, params ObjectParameter[] sqlParams) where T : class, new()
        {
            return await this.ExecuteProcedureAndGetResultsAsync<T>(procedureCommand, sqlParams);
        }

        public async Task<int> ExecuteProcedureAsync(string name, params ObjectParameter[] parameters)
        {
            return await this.procCalling.ExecuteProcedureAsync(name, parameters);
        }

        public IEnumerable<T> ExecuteProcedureRetOracle<T>(string procedureCommand, string outputParam, params ObjectParameter[] sqlParams) where T : class, new()
        {
            return this.procCalling.ExecuteProcedureRetOracle<T>(procedureCommand, outputParam, sqlParams);
        }

        public async Task<IEnumerable<T>> ExecuteProcedureRetOracleAsync<T>(string procedureCommand, string outputParam, params ObjectParameter[] sqlParams) where T : class, new()
        {
            return await this.procCalling.ExecuteProcedureRetOracleAsync<T>(procedureCommand, outputParam, sqlParams);
        }

        public T ExecuteQuerySingle<T>(string query, object Params)
        {
            return this.procCalling.ExecuteQuerySingle<T>(query, Params);
        }

        public async Task<T> ExecuteQuerySingleAsync<T>(string query, object Params)
        {
            return await this.procCalling.ExecuteQuerySingleAsync<T>(query, Params);
        }

        public T ExecuteQuerySingleOrDefault<T>(string query, object Params) where T : class, new()
        {
            return this.procCalling.ExecuteQuerySingleOrDefault<T>(query, Params);
        }

        public async Task<T> ExecuteQuerySingleOrDefaultAsync<T>(string query, object Params) where T : class, new()
        {
            return await this.procCalling.ExecuteQuerySingleOrDefaultAsync<T>(query, Params);
        }

        public IEnumerable<T> ExecuteQueryWithDapperRet<T>(string query, object Params) where T : class, new()
        {
            return this.procCalling.ExecuteQueryWithDapperRet<T>(query, Params);
        }

        public async Task<IEnumerable<T>> ExecuteQueryWithDapperRetAsync<T>(string query, object Params) where T : class, new()
        {
            return await this.procCalling.ExecuteQueryWithDapperRetAsync<T>(query, Params);
        }

        public IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.Set<T>().Where(predicate).AsNoTracking();
        }

        public T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.Set<T>().FirstOrDefault(predicate);
        }

        public async Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await this.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return this.Set<T>().AsQueryable();
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return this.context.Set<TEntity>();
        }
    }





    public interface IRepositoryFactory
    {
        IRepository Create(string name);
    }

    public class RepositoryFactory : IRepositoryFactory
    {


        IServiceProvider _serviceProvider;
        IProcedureCallingFactory _procFactory;
        IConfiguration _configuration;
        public RepositoryFactory(IConfiguration configuration, IServiceProvider serviceProvider, IProcedureCallingFactory procFactory)
        {
            this._serviceProvider = serviceProvider;
            this._procFactory = procFactory;
            this._configuration = configuration;
        }

        public IRepository Create(string name)
        {

            string provider = _configuration.GetConnectionString(name + "_PROVIDER");
            string connection = _configuration.GetConnectionString(name);
            IProcedureCalling procCalling = this._procFactory.Create(provider, connection);
            IRepository ret = null;
            DbContext _db = null;
            string context = _configuration.GetConnectionString(name + "_CONTEXT");

            if (context != null)
            {
                var myContextType = Type.GetType(context);
                if (myContextType != null)
                {
                    _db = (DbContext)this._serviceProvider.GetService(myContextType);
                }
            }
            ret = new Repository(_db, procCalling);



            return ret;

        }
    }
}
