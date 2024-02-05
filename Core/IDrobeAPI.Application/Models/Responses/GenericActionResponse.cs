using IDrobeAPI.Application.Interfaces.IResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Models.Responses;

public class GenericActionResponse<T> /*: IGenericActionResponse<T>*/
{
    private bool _requestSuccessful;
    private HttpStatusCode _statusCode;
    private string _message;
    private T _data;

    public GenericActionResponse(bool success, HttpStatusCode statusCode, T data, string message)
    {
        this._requestSuccessful = success;
        this._statusCode = statusCode;
        this._data = data;
        this._message = message;
    }

    //public GenericActionResponse(bool success, HttpStatusCode statusCode)
    //{
    //    this._requestSuccessful = success;
    //    this._statusCode = statusCode;
    //    this.Data = default(T);
    //}

    //public bool RecordIsNull
    //{
    //    get
    //    {
    //        return this.Data == null;
    //    }
    //}

    public bool RequestSuccessful
    {
        get { return this._requestSuccessful; }
        set { this._requestSuccessful= value;}
    }

    public HttpStatusCode ResponseCode
    {
        get { return this._statusCode; }
        set { this._statusCode = value;}
    }

    public string Message
    {
        get { return this._message; }
        set { this._message = value;}
    }

    public T Data
    {
        get { return this._data; }
        set { this._data = value; }
    }
}
