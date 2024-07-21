using System.Data;
using System.Linq.Expressions;
using CleanCodeArchitecture.Domain.Core.Entities;
using CleanCodeArchitecture.Domain.Core.Repositories;
using CleanCodeArchitecture.Infrastructure.SqlKataDapper.Extensions;
using Dapper;
using SqlKata;
using SqlKata.Compilers;

namespace CleanCodeArchitecture.Infrastructure.SqlKataDapper.Data;

public abstract class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T>  where T : BaseEntity
{
    private readonly ApplicationConnection _applicationConnection;


    /// <summary>
    /// Gets or sets the query timeout.
    /// </summary>
    public int QueryTimeout { get; set; } = 30;

    /// <summary>
    /// Gets the connection.
    /// </summary>
    protected IDbConnection Connection { get; private set; }

    /// <summary>
    /// Gets or sets the compiler.
    /// </summary>
    protected Compiler Compiler { get; set; }


    public virtual string TableName { get; set; }

    private Query _baseQuery;

    protected BaseRepositoryAsync(ApplicationConnection applicationConnection)
    {
        
        this.Connection = applicationConnection.GetConnection();
        this.Compiler = applicationConnection.Compiler;

        this._baseQuery = new Query(this.TableName);
    }


    public async Task<T?> GetByIdAsync(Guid id)
    {
        
        Query query = this._baseQuery.Where("Id", id);

        return await this.Connection.QuerySingleOrDefaultAsync<T>(this.GetCommandDefinitionByQuery(query));
    }

    public async Task<IEnumerable<T>> ListAllAsync()
    {
        return await this.Connection.QueryAsync<T>(this.GetCommandDefinitionByQuery(this._baseQuery));
    }

    public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> criteria)
    {
        Query query = this._baseQuery.ToSqlWhereClause(criteria);

        return await this.Connection.QueryAsync<T>(this.GetCommandDefinitionByQuery(query));
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> criteria)
    {
        throw new NotImplementedException();
    }

    public async Task<T> AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    internal CommandDefinition GetCommandDefinitionByQuery(Query query, CommandFlags flags = CommandFlags.Buffered)
    {
        var compiled = this.CompileAndLog(query);

        return new CommandDefinition(
            commandText: compiled.Sql.Replace("URLQUERY", "?"),
            parameters: compiled.NamedBindings,
            cancellationToken: default,
            flags: flags
        );
    }

    internal SqlResult CompileAndLog(Query query)
    {
        var compiled = this.Compiler.Compile(query);

        return compiled;
    }


    private void ReleaseUnmanagedResources()
    {
        // TODO release unmanaged resources here
    }

    private void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if (disposing)
        {
            _applicationConnection.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private async ValueTask DisposeAsyncCore()
    {
        ReleaseUnmanagedResources();

        await _applicationConnection.DisposeAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();
        GC.SuppressFinalize(this);
    }

    ~BaseRepositoryAsync()
    {
        Dispose(false);
    }
}