using AutoMapper;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Categories.Constants;
using IDrobeAPI.Application.Features.Categories.Rules;
using IDrobeAPI.Application.Interfaces.IUnitOfWorks;
using IDrobeAPI.Application.Models.Responses;
using IDrobeAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Commands.UpdateCategories;

public class UpdateCategoryCommandHandler : BaseHandler, IRequestHandler<UpdateCategoryCommandRequest, ActionResponse>
{
    private readonly CategoryRules _categoryRules;

    public UpdateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, CategoryRules categoryRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _categoryRules = categoryRules;
    }

    public async Task<ActionResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        ActionResponse response = new ActionResponse(false, System.Net.HttpStatusCode.BadRequest, "Bad Request");

        Category oldData = await unitOfWork.GetReadRepository<Category>().GetSingleAsync(id=> id.Id == request.Id, enableTracking:true);//todo burda tracikg true olmalidi axi
        //category var/yox
        _categoryRules.CategoryShouldExistWhenRequested(oldData);

        var newData = mapper.Map(request, oldData);

        _categoryRules.EntityCanNotBeNull(newData);

        bool result = unitOfWork.GetWriteRepository<Category>().UpdateAsync(newData);
        //update olmagi
        _categoryRules.CategoryResultProblem(result);

        int rowAffect = await unitOfWork.SaveAsync();
        //db dusmeyi
        _categoryRules.CategoryRowAffectProblem(rowAffect);

        response.RequestSuccessful = true;
        response.ResponseCode = System.Net.HttpStatusCode.OK;
        response.Message = $"{oldData.Name} {CategoryResponseMessageConstants.successfullyUpdated}";//todo burda teze name de ola bilerdi - UpdateCategoryCommandHandler

        return response;
    }
}
