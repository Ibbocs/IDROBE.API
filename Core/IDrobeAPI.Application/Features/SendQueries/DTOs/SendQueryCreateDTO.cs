using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.SendQueries.DTOs;

public class SendQueryCreateDTO
{
    public string StoreName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Addres { get; set; }
}
