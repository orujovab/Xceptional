using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.MotherBoardDTOs
{
    public class MotherBoardPostDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public bool IsAvailable { get; set; }
        public double? Price { get; set; }
        public int Count { get; set; }
    }

    public class MotherBoardPostDtoValidator : AbstractValidator<MotherBoardPostDto>
    {
        public MotherBoardPostDtoValidator()
        {
            RuleFor(x => x.ModelName).MaximumLength(50).NotEmpty().WithMessage("model is required");
            RuleFor(x => x.Count).NotEmpty().WithMessage("model is required");
        }
    }
}
