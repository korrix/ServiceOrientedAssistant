using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TodoService
{
    [ServiceContract]
    public interface ITodoService
    {
        [OperationContract]
        int RememberTodo(string todo);

        [OperationContract]
        bool MarkDone(int id);

        [OperationContract]
        List<Todo> GetTodos();
    }

    [DataContract]
    public class Todo
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Task { get; set; }

        [DataMember]
        public bool Done { get; set; }
    }
}
