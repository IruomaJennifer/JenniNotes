using JenniNotes.Application.FetchNotes;
using JenniNotes.Infrastructure;
using JenniNotes.Infrastructure.Nhibernate;

namespace JenniNotes.Application
{
    public abstract class BaseService<Request, Response>(DbContext dbContext, DatabasePipeline pipeline, ILogger<BaseService> logger) : BaseService(dbContext, pipeline, logger), IBaseService<Request, Response>
    {
        public abstract Task<Output<Response>> ExecuteAsync(Request request);

        public Task<Output<Response>> FailedResult(string error, int statusCode = 500)
        {
            return Task.FromResult(error == null? Output<Response>.Failure(statusCode): Output<Response>.Failure(statusCode).AddError(error));
        }
        public Task<Output<Response>> SuccessfulResult(Response data)
        {
            return Task.FromResult(Output<Response>.Successful(data));

        }
        public Task<Output<Response>> SuccessfulResult(Response data, int currentPage, int totalPages, int pageSize,int entityCount)
        {
            return Task.FromResult(PaginatedOutput<Response>.Successful(data, currentPage,totalPages,pageSize, entityCount));

        }
    }
    public abstract class BaseService<Request>(DbContext dbContext, DatabasePipeline pipeline, ILogger<BaseService> logger) : BaseService(dbContext, pipeline, logger), IBaseService<Request>
    {
        public abstract Task<Output> ExecuteAsync(Request request);

        public Task<Output> FailedResult(string error, int statusCode = StatusCodes.Status500InternalServerError)
        {
            return Task.FromResult(error == null ? Output.Failure(statusCode) : Output.Failure(statusCode).AddError(error));
        }

        public Task<Output> SuccessfulResult()
        {
            return Task.FromResult(Output.Successful());
        }
    }
    public abstract class BaseService(DbContext dbContext, DatabasePipeline pipeline, ILogger<BaseService> logger)
    {
        protected DatabasePipeline Pipeline { get; set; } = pipeline;
        protected DbContext DbContext { get; set; } = dbContext;
        protected ILogger Logger { get; set; } = logger;
    }
    public interface IBaseService<Request>
    {
        Task<Output> ExecuteAsync(Request request);
        Task<Output> SuccessfulResult();
        Task<Output> FailedResult(string error, int statusCode = StatusCodes.Status500InternalServerError);
    }

    public interface IBaseService<Request, Response> 
    {
        Task<Output<Response>> ExecuteAsync(Request request);
        Task<Output<Response>> SuccessfulResult(Response data);
        Task<Output<Response>> FailedResult(string error, int statusCode = StatusCodes.Status500InternalServerError);
    }
}
