using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace IDrobeAPI.Application.Exceptions.Problems;

public class ValidationProblemDetails : ProblemDetails
{
    public object Errors { get; set; }

    public override string ToString() => JsonConvert.SerializeObject(this);
}