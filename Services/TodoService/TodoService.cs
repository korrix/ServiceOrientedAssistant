using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TodoService
{
     public class TodoService : ITodoService
    {
        private const string _connection = @"C:\tmp\todo.db";
        public int RememberTodo(string todo)
        {
            using (var db = new LiteDatabase(_connection))
            {
                var t = db.GetCollection<Todo>("todo");
                return t.Insert(new Todo()
                {
                    Task = todo,
                    Done = false
                });
            }
        }

        public List<Todo> GetTodos()
        {
            using (var db = new LiteDatabase(_connection))
            {
                var t = db.GetCollection<Todo>("todo");
                return t.FindAll().ToList();
            }
        }

        public bool MarkDone(int id)
        {
            using (var db = new LiteDatabase(_connection))
            {
                var t = db.GetCollection<Todo>("todo");
                Todo x = t.FindById(id);
                x.Done = true;
                return t.Update(x);
            }
        }
    }
}
