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

namespace IDrobeAPI.Application.Features.Categories.Commands.CreateCategories;

public class CreateCategoryCommandHandler : BaseHandler, IRequestHandler<CreateCategoryCommandRequest, ActionResponse>
{
    //private readonly IBrandRepository _brandRepository;
    private readonly CategoryRules _categoryRules;

    public CreateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, CategoryRules categoryRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _categoryRules = categoryRules;
    }

    public async Task<ActionResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        ActionResponse response = new ActionResponse(false, System.Net.HttpStatusCode.BadRequest, "Bad Request");
        //todo Eyni Priortyli data olmamalidi database hissesinde eyni parantId altinda
        var entity = mapper.Map<Category>(request);
        
        _categoryRules.EntityCanNotBeNull(entity);

        var result = await unitOfWork.GetWriteRepository<Category>().AddAsync(entity);
        //result yoxla
        _categoryRules.CategoryResultProblem(result);

        int rowAffect = await unitOfWork.SaveAsync();
        //rowaffect yoxla
        _categoryRules.CategoryRowAffectProblem(rowAffect);

        response.RequestSuccessful = true;
        response.ResponseCode = System.Net.HttpStatusCode.Created;
        response.Message = $"{request.Name} {CategoryResponseMessageConstants.successfullyCreated}";

        return response;
    }
}
