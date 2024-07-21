using System.Data;
using Microsoft.Data.SqlClient;
using SqlKata.Compilers;

namespace CleanCodeArchitecture.Infrastructure.SqlKataDapper.Data;

public class ApplicationConnection : IDisposable
{
    private SqlConnection mySqlConnection;

    public Compiler Compiler { get; private set; }

    private string connectionString { get; set; }

    public ApplicationConnection(string connectionString)
    {
        this.connectionString = connectionString;
        this.Compiler = new SqlServerCompiler();
    }

    public IDbConnection GetConnection()
    {
        this.mySqlConnection ??= new SqlConnection(this.connectionString);

        if (this.mySqlConnection.State != ConnectionState.Open)
            this.mySqlConnection.Open();



        return this.mySqlConnection;
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();

        Dispose(disposing: false);
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        GC.SuppressFinalize(this);
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (mySqlConnection.State == ConnectionState.Open)
                mySqlConnection.Close();

            mySqlConnection?.Dispose();
        }

        mySqlConnection = null;
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (mySqlConnection is not null)
        {
            if (mySqlConnection.State == ConnectionState.Open)
                await mySqlConnection.CloseAsync();

            await mySqlConnection.DisposeAsync().ConfigureAwait(false);
        }



        mySqlConnection = null;
    }
}
