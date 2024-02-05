using IDrobeAPI.Application.Interfaces.IResponses;
using System.Net;

namespace IDrobeAPI.Application.Models.Responses;

public class ActionResponse /*: IActionResponse*/
{
    private bool _requestSuccessful;
    private HttpStatusCode _statusCode;
    private string _message;

    public ActionResponse(bool success, HttpStatusCode statusCode, string message)
    {
        this._requestSuccessful = success;
        this._statusCode = statusCode;
        _message = message;
    }

    public bool RequestSuccessful
    {
        get{ return this._requestSuccessful; }
        set { this._requestSuccessful = value; }
    }

    public HttpStatusCode ResponseCode
    {
        get { return this._statusCode; }
        set { this._statusCode = value; }
    }

    public string Message
    {
        get { return this._message; }
        set { this._message = value; }
    }
}
