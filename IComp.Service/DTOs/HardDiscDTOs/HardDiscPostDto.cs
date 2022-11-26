using FluentValidation;
using IComp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.HardDiscDTOs
{
    public class HardDiscPostDto
    {
        public int HDDCapacityId { get; set; }
        public string ModelName { get; set; }
        public bool IsAvailable { get; set; }
        public HDDCapacity HDDCapacity { get; set; }

    }

    public class HardDiscPostDtoValidator : AbstractValidator<HardDiscPostDto>
    {
        public HardDiscPostDtoValidator()
        {
            RuleFor(x => x.ModelName).MaximumLength(50).NotEmpty().WithMessage("model is required");
        }
    }
}
