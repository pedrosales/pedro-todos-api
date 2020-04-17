using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Nova tarefa 1", DateTime.Now, "Usuario A"));
            _items.Add(new TodoItem("Nova tarefa 2", DateTime.Now, "Usuario A"));
            _items.Add(new TodoItem("Nova tarefa 3", DateTime.Now, "Pedro Ivo"));
            _items.Add(new TodoItem("Nova tarefa 4", DateTime.Now, "Usuario A"));
            _items.Add(new TodoItem("Nova tarefa 5", DateTime.Now, "Pedro Ivo"));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_pedro_ivo()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Pedro Ivo"));
            Assert.AreEqual(2, result.Count());
        }
    }
}