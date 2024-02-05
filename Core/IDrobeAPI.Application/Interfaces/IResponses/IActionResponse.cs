using System.Net;

namespace IDrobeAPI.Application.Interfaces.IResponses
{
    public interface IActionResponse
    {
        bool RequestSuccessful { get; set; }
        HttpStatusCode ResponseCode { get; set; }
        string Message { get; set; }
    }
}
