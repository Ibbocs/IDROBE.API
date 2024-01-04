using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Beheviors
{
    //beheviors middileware oxsayir amma middileware bir-birine bagli piplineda is gorurse, bunlar ele elemir, heresi oz isi olanda isleyir. filtir kimi
    public class FluentValidationBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>//mediatr pipeline behavioru
         where TRequest : IRequest<TResponse> //requstimin isarelendiyi interface
    {
        private readonly IEnumerable<IValidator<TRequest>> validator;

        public FluentValidationBehevior(IEnumerable<IValidator<TRequest>> validator)
        {
            this.validator = validator;
        }
        //requestde validation neticelerin yoxlayir ve xeta varsa error atir, yoxdusa responsa kecir
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failtures = validator
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .GroupBy(x => x.ErrorMessage)
                .Select(x => x.First())
                .Where(f => f != null)
                .ToList();

            if (failtures.Any())
                throw new ValidationException(failtures);

            return next();
        }
    }
}
