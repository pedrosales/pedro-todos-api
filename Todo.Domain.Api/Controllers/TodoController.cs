using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public GenericCommandResult Create(
            [FromBody]CreateTodoCommand command,
            [FromServices]TodoHandler handler
        )
        {
            command.User = "pedroivo";
            var result = (GenericCommandResult)handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("")]
        public GenericCommandResult Put(
            [FromBody]UpdateTodoCommand command,
            [FromServices]TodoHandler handler
        )
        {
            command.User = "pedroivo";
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("mark-as-done")]
        public GenericCommandResult MarkAsDone(
            [FromBody]MarkTodoAsDoneCommand command,
            [FromServices]TodoHandler handler
        )
        {
            command.User = "pedroivo";
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("mark-as-undone")]
        public GenericCommandResult MarkAsUndone(
            [FromBody]MarkTodoAsUndoneCommand command,
            [FromServices]TodoHandler handler
        )
        {
            command.User = "pedroivo";
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<TodoItem> GetAll(
            [FromServices]ITodoRepository repository
        )
        {
            return repository.GetAll("pedroivo");
        }

        [HttpGet]
        [Route("done")]
        public IEnumerable<TodoItem> GetAllDone(
            [FromServices]ITodoRepository repository
        )
        {
            return repository.GetAllDone("pedroivo");
        }

        [HttpGet]
        [Route("undone")]
        public IEnumerable<TodoItem> GetAllUndone(
            [FromServices]ITodoRepository repository
        )
        {
            return repository.GetAllUndone("pedroivo");
        }

        [HttpGet]
        [Route("done/today")]
        public IEnumerable<TodoItem> GetAllDoneToday(
            [FromServices]ITodoRepository repository
        )
        {
            return repository.GetByPeriod("pedroivo", DateTime.Now.Date, true);
        }

        [HttpGet]
        [Route("undone/today")]
        public IEnumerable<TodoItem> GetAllUndoneToday(
            [FromServices]ITodoRepository repository
        )
        {
            return repository.GetByPeriod("pedroivo", DateTime.Now.Date, false);
        }

        [HttpGet]
        [Route("done/tomorrow")]
        public IEnumerable<TodoItem> GetAllDoneTomorrow(
            [FromServices]ITodoRepository repository
        )
        {
            return repository.GetByPeriod("pedroivo", DateTime.Now.Date.AddDays(1), true);
        }

        [HttpGet]
        [Route("undone/tomorrow")]
        public IEnumerable<TodoItem> GetAllUndoneTomorrow(
            [FromServices]ITodoRepository repository
        )
        {
            return repository.GetByPeriod("pedroivo", DateTime.Now.Date.AddDays(1), false);
        }
    }
}