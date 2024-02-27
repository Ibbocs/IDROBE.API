//using AutoMapper;
//using IDrobeAPI.Application.BaseObjects;
//using IDrobeAPI.Application.Features.SendQueries.Constants;
//using IDrobeAPI.Application.Interfaces.IUnitOfWorks;
//using IDrobeAPI.Application.Interfaces.IServices.SendQueryServices;
//using IDrobeAPI.Application.Models.Responses;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace IDrobeAPI.Application.Features.SendQueries.Commands;

//public class CreateSendQueryCommandHandler : BaseHandler, IRequestHandler<CreateSendQueryCommandRequest, GenericActionResponse<bool>>
//{
//    private readonly ISendQueryService _sendQueryService;
//    public CreateSendQueryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ISendQueryService sendQueryService) : base(mapper, unitOfWork, httpContextAccessor)
//    {
//        _sendQueryService = sendQueryService;
//    }

//    public async Task<GenericActionResponse<bool>> Handle(CreateSendQueryCommandRequest request, CancellationToken cancellationToken)
//    {
//        GenericActionResponse<bool> response = new GenericActionResponse<bool>(false, System.Net.HttpStatusCode.BadRequest, false, SendQueryResponseMessageConstants.responseMessageError);

//        //todo bir sekil gelmelidir serti yoxlamaq olar meselen
//        bool data = _sendQueryService.SendQuery(request.Model);
//        await Task.Delay(TimeSpan.FromMilliseconds(1));
//        //bool data = await Task.Run(() => _sendQueryService.SendQuery(request.Model));

//        if (data)
//        {
//            response.Message = SendQueryResponseMessageConstants.responseMessage;
//            response.ResponseCode = System.Net.HttpStatusCode.OK;
//            response.Data = true;
//            response.RequestSuccessful = true;
//            return response;
//        }

//        return response;

//    }
//}
