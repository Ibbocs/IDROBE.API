using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Exceptions.CustomExceptions;
using IDrobeAPI.Application.Features.Products.Constants;
using IDrobeAPI.Application.Interfaces.IPagination;
using IDrobeAPI.Application.Interfaces.IUnitOfWorks;
using IDrobeAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IDrobeAPI.Application.Features.Products.Rules;

public class ProductRules:BaseRules
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductRules(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CategoriesShouldBeExisted(IList<int> categoryIds)
    {
        CategoryCanNotBeSame(categoryIds);

        var categories = await _unitOfWork.GetReadRepository<Category>().GetAllAsync();

        var nonExistentCategories = categoryIds.Where(id => !categories.Any(c => c.Id == id)).ToList();

        if (nonExistentCategories.Any())
        {
            throw new Exception($"{ProductExceptionMessageConstants.dontFindCategory} {string.Join(", ", nonExistentCategories)}");
        }
    }

    public void CategoryCanNotBeSame(IList<int> categoryIds)
    {
        var duplicateCategories = categoryIds.GroupBy(x => x)
                                        .Where(g => g.Count() > 1)
                                        .Select(y => y.Key)
                                        .ToList();

        if (duplicateCategories.Any())
        {
            throw new BusinessException($"{ProductExceptionMessageConstants.duplicateCategoryId} {string.Join(", ", duplicateCategories)}");
        }
    }

    public void ProductCanNotBeNull(Product product)
    {
        if (product == null)
            throw new BusinessException(ProductExceptionMessageConstants.canNotNull);
    }

    public void ProductCategoryResultProblem(bool result, int item)
    {
        if (!result)
            throw new BusinessException($"{ProductExceptionMessageConstants.resultProblemProductCategory} : {item}");
    }

    public void ProductResultProblem(bool result)
    {
        if (!result)
            throw new BusinessException(ProductExceptionMessageConstants.resultProblemProduct);
    }

    public void ProductRowAffectProblem(int rowAffect)
    {
        if (rowAffect < 1)
            throw new BusinessException(ProductExceptionMessageConstants.rowAffectProblemProduct);
    }

    public void ProductCategoryRowAffectProblem(int rowAffect)
    {
        if (rowAffect < 1)
            throw new BusinessException(ProductExceptionMessageConstants.rowAffectProblemProductCategory);
    }

    public async Task BrandShouldBeExisted(int brandId)
    {
        var brand = await _unitOfWork.GetReadRepository<Brand>().GetSingleAsync(br=> br.Id == brandId);
        if (brand == null)
            throw new BusinessException($"{ProductExceptionMessageConstants.dontFindBrand} {brandId}");

    }

    public void ProductShouldExistWhenRequested(Product product, int id)
    {
        if (product is null)
        {
            throw new BusinessException($"{ProductExceptionMessageConstants.dontFindProduct} {id}");
        }
    }

    public void ProductShouldExistWhenRequested(Product product)
    {
        if (product is null)
        {
            throw new BusinessException($"{ProductExceptionMessageConstants.dontFindProduct}");
        }
    }
}
