namespace SC.VersionManagement.Models
{
    public class SuccessResponse<T>
    {
        public SuccessResponse()
        {

        }
        public SuccessResponse(T data)
        {
            Data = data;
        }
        public T Data { get; set; }

    }
}
