using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace IDrobeAPI.Application.Exceptions.Problems;

public class BusinessProblemDetails : ProblemDetails
{
    public override string ToString() => JsonConvert.SerializeObject(this);
}