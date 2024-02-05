using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Exceptions.CustomExceptions;
using IDrobeAPI.Application.Features.Categories.Constants;
using IDrobeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Rules;

public class CategoryRules:BaseRules
{
    public void EntityCanNotBeNull(Category entity)
    {
        if (entity == null)
            throw new BusinessException(CategoryExceptionMessageConstants.canNotNull);
    }

    public void CategoryResultProblem(bool result)
    {
        if (!result)
            throw new BusinessException(CategoryExceptionMessageConstants.resultProblem);
    }

    public void CategoryRowAffectProblem(int rowAffect)
    {
        if (rowAffect != 1)
            throw new BusinessException(CategoryExceptionMessageConstants.rowAffectProblem);
    }

    public void CategoryShouldExistWhenRequested(Category oldData)
    {
        if (oldData == null)
            throw new BusinessException(CategoryExceptionMessageConstants.dontFindCategory);
    }
}
