using IDrobeAPI.Application.DTOs.SendQueriesDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Models.SendQueries;

public class SendQueryModel
{
    public SendQueryCreateDTO QueryInfo { get; set; }
    public IFormFileCollection StoreLogos { get; set; }
}
