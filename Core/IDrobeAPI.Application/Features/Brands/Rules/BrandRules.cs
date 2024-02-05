using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Exceptions.CustomExceptions;
using IDrobeAPI.Application.Features.Brands.Constants;
using IDrobeAPI.Application.Features.Categories.Constants;
using IDrobeAPI.Application.Interfaces.IUnitOfWorks;
using IDrobeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Rules;

public class BrandRules:BaseRules
{
    private readonly IUnitOfWork _unitOfWork;
    public BrandRules(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void BrandResultProblem(bool result)
    {
        if (!result)
            throw new BusinessException(BrandExceptionMessageConstants.resultProblem);
    }

    public void BrandRowAffectProblem(int rowAffect)
    {
        if (rowAffect != 1)
            throw new BusinessException(BrandExceptionMessageConstants.rowAffectProblem);
    }

    public void EntityCanNotBeNull(Brand entity)
    {
        if (entity == null)
            throw new BusinessException(BrandExceptionMessageConstants.canNotNull);
    }

    public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
    {
        var data = await _unitOfWork.GetReadRepository<Brand>().GetSingleAsync(n=> n.BrandName == name);
        if (data != null)
        {
            throw new BusinessException($"{name} - {BrandExceptionMessageConstants.sameName}");
        }
    }

    public void BrandShouldExistWhenRequested(Brand oldData)
    {
        if (oldData == null)
            throw new BusinessException(BrandExceptionMessageConstants.dontFind);
    }
}
