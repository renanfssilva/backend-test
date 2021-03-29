namespace ScoreCombination.Domain.Interfaces.Validators
{
    public interface IValidatorBase<TEntity> where TEntity : class
    {
        void Validate(TEntity request);
    }
}
