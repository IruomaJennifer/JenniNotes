namespace JenniNotes.Infrastructure
{
    public class Output
    {
        public int StatusCode { get; protected set; }
        public bool IsSuccessful { get; protected set; }
        public bool NotSuccessful => IsSuccessful == false;
        public List<string> Errors { get; protected set; } = new List<string>();
        public Output AddError(string message)
        {
            Errors.Add(message);
            return this;
        }
        public Output SetErrors(IEnumerable<string> errors)
        {
            Errors.AddRange(errors);
            return this;
        }
        public static Output Failure(int statusCode = StatusCodes.Status500InternalServerError)
        {
            return new Output { StatusCode = statusCode, IsSuccessful = false };
        }
        public static Output Successful()
        {
            return new Output { StatusCode = StatusCodes.Status200OK, IsSuccessful = true };
        }
    }

    public class Output<T> : Output
    {
        public T Data { get; set; }
        public Output<T> AddError(string message)
        {
            Errors.Add(message);
            return this;
        }
        public Output<T> SetErrors(IEnumerable<string> errors)
        {
            Errors.AddRange(errors);
            return this;
        }
        public static Output<T> Successful(T data)
        {
            return new Output<T> { Data = data, StatusCode = StatusCodes.Status200OK, IsSuccessful = true };
        }

        public new static Output<T> Failure(int statusCode = StatusCodes.Status500InternalServerError)
        {
            return new Output<T> { StatusCode = statusCode, IsSuccessful = false };
        }           
    }

    public class PaginatedOutput<T> : Output<T>
    {
        public static Output<T> Successful(T data, int current, int totalPages, int currentSize, int totalSize)
        {
            return new PaginatedOutput<T>
            {
                Data = data,
                StatusCode = StatusCodes.Status200OK,
                CurrentPage = current,
                NumberOfPages = totalPages,
                CurrentPageSize = currentSize,
                TotalSize = totalSize
            };
        }
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPageSize { get; set; }
        public int TotalSize { get; set; }
    }
}
