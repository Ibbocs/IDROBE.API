//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using Microsoft.EntityFrameworkCore.Query;
//using Microsoft.EntityFrameworkCore;
//using System.Linq.Expressions;
//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using AutoMapper;
//using IDrobeAPI.Application.Features.Categories.Commands.UpdateCategories;
//using IDrobeAPI.Application.Features.Categories.Constants;
//using IDrobeAPI.Application.Features.Categories.Rules;
//using IDrobeAPI.Application.Models.Responses;
//using IDrobeAPI.Domain.Entities;
//using IDrobeAPI.Persistence.Implementation.UnitOfWorks;

//namespace IDrobeAPI.API
//{
//    public class jcnsdj
//    {
//        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
//            IIncludableQueryable<T, object>>? include = null, bool enableTracking = false, bool isDeleted = false)
//        {
//            IQueryable<T> queryable = Table;
//            if (!enableTracking) queryable = queryable.AsNoTracking();
//            if (isDeleted) queryable = queryable.IgnoreQueryFilters();
//            if (include is not null) queryable = include(queryable);

//            //queryable.Where(predicate);

//            return await queryable.FirstOrDefaultAsync(predicate);
//        }

//        public bool UpdateAsync(T entity)
//        {
//            //await Task.Run(()
//            //    =>
//            //{
//            //    EntityEntry<T> entityEntry = Table.Update(entity);
//            //    return entityEntry.State == EntityState.Modified;

//            //});
//            //return false;

//            EntityEntry<T> entityEntry = Table.Update(entity);
//            return entityEntry.State == EntityState.Modified;
//        }

//        public async Task<ActionResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
//        {
//            ActionResponse response = new ActionResponse(false, System.Net.HttpStatusCode.BadRequest, "Bad Request");

//            Category oldData = await unitOfWork.GetReadRepository<Category>().GetSingleAsync(id => id.Id == request.Id, enableTracking: true);//todo burda tracikg true olmalidi axi
//                                                                                                                                              //category var/yox
//            _categoryRules.CategoryShouldExistWhenRequested(oldData);

//            Category newData = mapper.Map<Category>(request);
//            //mapleme nulllugu
//            _categoryRules.EntityCanNotBeNull(newData);

//            bool result = unitOfWork.GetWriteRepository<Category>().UpdateAsync(newData);
//            //update olmagi
//            _categoryRules.CategoryResultProblem(result);

//            int rowAffect = await unitOfWork.SaveAsync();
//            //db dusmeyi
//            _categoryRules.CategoryRowAffectProblem(rowAffect);

//            response.RequestSuccessful = true;
//            response.ResponseCode = System.Net.HttpStatusCode.OK;
//            response.Message = $"{oldData.Name} {CategoryResponseMessageConstants.successfullyUpdated}";//todo burda teze name de ola bilerdi - UpdateCategoryCommandHandler

//            return response;
//        }
//    }
//}
