using IDrobeAPI.Application.Models.Responses;
using IDrobeAPI.Application.Models.SendQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Interfaces.IServices.SendQueryServices;

public interface ISendQueryService
{
    public GenericActionResponse<bool> SendQuery(SendQueryModel model);
}
