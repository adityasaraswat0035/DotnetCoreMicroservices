using mango.web.Services.Contracts;
using mango.web.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mango.web.Validations.Attributes
{
    public class CategoryValidationAttribute : ValidationAttribute
    {


        //private readonly string _comparisonProperty;
        //public CategoryValidationAttribute(string comparisonProperty)
        //{
        //    _comparisonProperty = comparisonProperty;
        //}
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var fieldValue = (int)value;
                ICategoryService categoryService = validationContext.GetService(typeof(ICategoryService)) as ICategoryService;
                if (categoryService != null)
                {
                    var category = categoryService.GetCategoryAsync<CategoryDto>(fieldValue).GetAwaiter().GetResult();
                    if (category != null)
                        return ValidationResult.Success;
                    else
                        return new ValidationResult(ErrorMessage);
                }
                else
                {
                    throw new ApplicationException("Category Service does not exists");
                }
            }
            catch (Exception)
            {
                //Log the value
                return new ValidationResult(ErrorMessage);
            }
            //var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
        }
    }
}
