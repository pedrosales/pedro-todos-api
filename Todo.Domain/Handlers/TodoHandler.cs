using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            // fail fast validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Criar um todo
            var todo = new TodoItem(command.Title, command.Date, command.User);

            // Salvar um todo no banco
            _repository.Create(todo);

            // Notificar usuário
            return new GenericCommandResult(true, "Tarefa Salva!", todo);

        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}