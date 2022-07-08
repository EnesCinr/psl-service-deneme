using Castle.DynamicProxy;
using FluentValidation;
using PSL.Core.CrossCuttingConcerns.Validation;
using PSL.Core.Utilities.Interceptors;
using PSL.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        #region Private Properties
        private readonly Type _validatorType;
        #endregion

        #region Constructors
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new System.Exception(AspectMessages.WrongType);

            _validatorType = validatorType;
        }
        #endregion

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext<object>(entity);
                ValidationTool.Validate(validator, validationContext);
            }
        }
    }
}
