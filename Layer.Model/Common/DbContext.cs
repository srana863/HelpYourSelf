using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Model.Common
{
    public class DbContext : IDisposable
    {
        private static DbContext _instance;
        private readonly DbProviderFactory _dbFactory;
        private readonly string _connectionString;
        public readonly DbConnection _connection;
        private DbDataAdapter _adapter;
        private DbCommand _command;
        private DbParameter _parameter;
        private int _commandTimeOut;
        public int CommandTimeOut { set { _commandTimeOut = value; } }
        public DbContext(string connectionString, string providerName)
        {
            _dbFactory = DbProviderFactories.GetFactory(providerName);
            _connectionString = connectionString;
            _connection = _dbFactory.CreateConnection();
            if (_connection != null)
                _connection.ConnectionString = _connectionString;
        }
        public void Open()
        {
            if (_connection.State == ConnectionState.Broken || _connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public void Close()
        {
            if (_connection.State == ConnectionState.Broken || _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _connection.Dispose();
                    _command.Dispose();
                    _adapter.Dispose();

                }
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
