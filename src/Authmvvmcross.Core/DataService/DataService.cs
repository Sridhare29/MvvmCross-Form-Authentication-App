using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AuthenticationApp.Model;
using SQLite;

namespace Authmvvmcross.Core.DataService
{
    public class DatabaseService : IDatabaseService
    {
        private readonly SQLiteConnection _connection;

        public DatabaseService()
        {
            var databasePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "database.db"
            );
            _connection = new SQLiteConnection(databasePath);
            _connection.CreateTable<User>();
        }

        public void Insert(User user)
        {
            _connection.Insert(user);
        }

        public void Update(User user)
        {
            _connection.Update(user);
        }

        public void Delete(User user)
        {
            _connection.Delete(user);
        }

        public User GetById(int id)
        {
            return _connection.Table<User>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _connection.Table<User>();
        }
    }

}
