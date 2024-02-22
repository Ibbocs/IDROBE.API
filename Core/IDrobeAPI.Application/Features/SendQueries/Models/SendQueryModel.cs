using IDrobeAPI.Application.Features.SendQueries.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.SendQueries.Models;

public class SendQueryModel
{
    public SendQueryCreateDTO QueryInfo { get; set; }
    public IFormFileCollection StoreLogos { get; set; }
}
