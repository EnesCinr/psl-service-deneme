using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
        #region Methods
        public async static void Validate(IValidator validator, IValidationContext entity)
        {
            var result = await validator.ValidateAsync(entity);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
        #endregion
    }
}
