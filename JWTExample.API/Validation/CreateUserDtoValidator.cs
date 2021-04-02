using FluentValidation;
using JWTExample.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.API.Validation
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Mail is required!").EmailAddress().WithMessage("E-Mail is wrong!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required!");
        }
    }
}
