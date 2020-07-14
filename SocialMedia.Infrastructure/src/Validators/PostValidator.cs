using FluentValidation;
using SocialMedia.Core.src.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.src.Validators
{
    /// <summary>
    /// Estas reglas necesitas ser identicas a que tiene el servidior.
    /// </summary>
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {

            RuleFor(post => post.Description)
                .NotNull()
                .Length(10,15);

            RuleFor(post => post.Date)
               .NotNull()
               .LessThan(DateTime.Now);


        }
    }
}
