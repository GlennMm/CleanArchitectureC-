namespace Application.ResponseModel
{
    public class Response<T>
    {
        public T Value { get; set; }
        public int Status;

        public Response(T value, int status = 200)
        {
            Value = value;
            Status = status;
        }
    }
}