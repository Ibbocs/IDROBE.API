using IDrobeAPI.Application.Features.SendQueries.Models;
using IDrobeAPI.Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Interfaces.IServices.SendQueryServices;

public interface ISendQueryService
{
    public Task<bool> SendQuery(SendQueryModel model);
}
