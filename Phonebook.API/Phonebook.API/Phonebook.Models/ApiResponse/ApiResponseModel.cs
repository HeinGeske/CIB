
namespace Phonebook.Models.ApiResponse
{
    public class ApiResponseModel<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
