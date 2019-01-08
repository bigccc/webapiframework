using FluentValidation;

namespace SWFU.CMS.Insfrastructure.Resources
{
    public class PostResourceValidator:AbstractValidator<PostResource>
    {
        public PostResourceValidator()
        {
            RuleFor(x => x.Author)
                .NotNull()
                .WithName("作者")
                .WithMessage("{PropertyName}是必填的")
                .MaximumLength(50);
        }
    }
}