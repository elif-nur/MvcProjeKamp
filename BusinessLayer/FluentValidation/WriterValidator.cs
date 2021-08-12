using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar unvanı boş geçilemez.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen 50 karakteri aşmayınız..");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz..");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Lütfen 50 karakteri aşmayınız..");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadı boş geçilemez.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmı boş geçilemez.");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Lütfen 100 karakteri aşmayınız.");
            //RuleFor(x => x.WriterAbout).Must(x=>x!=null && x.ToUpper().Contains("A")).WithMessage("Hakkında kısmında en az bir a harfi olmalıdır");
        }
    }
}
