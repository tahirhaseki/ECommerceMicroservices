using ECommerce.Web.Models.Catalog;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Validators
{
    public class CourseCreateInputValidator : AbstractValidator<CourseCreateInput>
    {
        public CourseCreateInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz.");
            RuleFor(x => x.Feature.Duration).NotEmpty().WithMessage("Süre alanı boş bırakılamaz.");
            /// ####.##
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat alanı boş bırakılamaz.").ScalePrecision(2, 6).WithMessage("Hatalı fiyatlandırma");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori alanı seçiniz");


        }
    }
}
