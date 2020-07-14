namespace SocialMedia.Api.Responses
{
    public class ApiResponse<T>
    {

        public ApiResponse(T data)
        {
            Data = data;
        }


        /// <summary>
        /// 
        /// </summary>
        public T Data { get; set; }
    }
}
