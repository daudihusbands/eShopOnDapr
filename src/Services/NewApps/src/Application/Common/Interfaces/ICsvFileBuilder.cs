using NewApps.Application.TodoLists.Queries.ExportTodos;

namespace NewApps.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
