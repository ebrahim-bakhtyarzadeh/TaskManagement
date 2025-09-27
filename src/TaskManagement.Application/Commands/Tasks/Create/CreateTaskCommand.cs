using Common.Application.Exceptions;
using Common.Application.Result;
using MediatR;
using TaskManagement.Application.Commands.Tasks._Common;
using TaskManagement.Domain.TasksAgg.Factories;
using TaskManagement.Domain.TasksAgg.Repository;
namespace TaskManagement.Application.Commands.Tasks.Create
{
    public class CreateTaskCommand : TaskCommand, IRequest<OperationResult>
    {

        public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, OperationResult>
        {

            private readonly ITaskRepository _taskRepository;
            private readonly ITaskFactory _taskFactory;

            public CreateTaskCommandHandler(ITaskRepository taskRepository, ITaskFactory taskFactory)
            {
                _taskFactory = taskFactory;
                _taskRepository = taskRepository;
            }

            public async Task<OperationResult> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
            {
                try
                {
					 Domain.TasksAgg.Models.Tasks workItem;

                    // به دلیل وجود داشتن else if مشکلی در تکرار ذخیره سازی وظیفه ایجاد نخواهد شد
                    if (request.StartTime == TaskStartTimes.ForNow)
                    {
                        workItem = _taskFactory.CreateTaskForNow(request.userId,request.Name, request.Description);
                        _taskRepository.Add(workItem);
                    }
                    else if (request.StartTime == TaskStartTimes.ForTommorow)
                    {
                        workItem = _taskFactory.CreateTaskForTomorrow(request.userId, request.Name, request.Description);
                        _taskRepository.Add(workItem);
                    }
                    else if (request.StartTime == TaskStartTimes.ForNextWeek)
                    {
                        workItem = _taskFactory.CreateTaskForNextWeek(request.userId, request.Name, request.Description);
                        _taskRepository.Add(workItem);
                        
                    }
                    await _taskRepository.Save();

                    return OperationResult.Success("ثبت وظیفه با موفقیت انجام شد");
                }
                catch
                {

                    throw new ServerErrorException();
                }
            }
        }
    }
}
