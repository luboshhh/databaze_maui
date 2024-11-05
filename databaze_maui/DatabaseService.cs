using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace databaze_maui
{
    public class DatabaseService
    {
        private readonly SQLiteConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Person>(); 
        }

        
        public List<Person> GetAllPeople()
        {
            return _database.Table<Person>().ToList();
        }

        
        public void AddPerson(Person person)
        {
            _database.Insert(person);
        }

    
        public void DeletePerson(int personId)
        {
            var person = _database.Table<Person>().FirstOrDefault(p => p.Id == personId);
            if (person != null)
            {
                _database.Delete(person);
            }
        }
    }
}