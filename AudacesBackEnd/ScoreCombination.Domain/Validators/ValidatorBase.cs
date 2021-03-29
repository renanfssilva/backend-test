using System;
using ScoreCombination.Domain.Interfaces.Validators;

namespace ScoreCombination.Domain.Validators
{
    public class ValidatorBase<TEntity> : IValidatorBase<TEntity> where TEntity : class
    {
        public void Validate(TEntity request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
        }
    }
}
