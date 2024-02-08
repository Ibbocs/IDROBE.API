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

namespace IDrobeAPI.Application.Features.Categories.Commands.DeleteCategories
{
    public class DeleteCategoryCommandHandler : BaseHandler, IRequestHandler<DeleteCategoryCommandRequest, ActionResponse>
    {
        private readonly CategoryRules _categoryRules;

        public DeleteCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, CategoryRules categoryRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _categoryRules = categoryRules;
        }

        public async Task<ActionResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            ActionResponse response = new ActionResponse(false, System.Net.HttpStatusCode.BadRequest, "Bad Request");

            Category deletedData= await unitOfWork.GetReadRepository<Category>().GetSingleAsync(id=>id.Id==request.Id, enableTracking:true); //todo repoda bulari task.Run cixard
            _categoryRules.CategoryShouldExistWhenRequested(deletedData);

            bool result = unitOfWork.GetWriteRepository<Category>().HardDelete(deletedData);
            _categoryRules.CategoryResultProblem(result);

            int rowAffect = await unitOfWork.SaveAsync();
            _categoryRules.CategoryRowAffectProblem(rowAffect);

            response.RequestSuccessful = true;
            response.ResponseCode = System.Net.HttpStatusCode.OK;
            response.Message = $"{deletedData.CategoryName} {CategoryResponseMessageConstants.successfullyDeleted}";

            return response;
        }
    }
}
