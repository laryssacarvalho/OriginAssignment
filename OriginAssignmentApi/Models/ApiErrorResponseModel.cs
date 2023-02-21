namespace OriginAssignmentApi.Models
{
    public class ApiErrorResponseModel
    {
        public IEnumerable<string> Errors { get; private set; }
        public ApiErrorResponseModel(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
