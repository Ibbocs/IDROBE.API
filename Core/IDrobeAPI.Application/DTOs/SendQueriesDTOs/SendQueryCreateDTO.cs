using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.DTOs.SendQueriesDTOs;

public class SendQueryCreateDTO
{
    public string StoreName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Addres { get; set; }
}
