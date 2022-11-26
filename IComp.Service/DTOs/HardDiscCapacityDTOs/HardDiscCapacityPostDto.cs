using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.HardDiscCapacityDTOs
{
    public class HardDiscCapacityPostDto
    {
        public string Capacity { get; set; }
        public string CycleRate { get; set; }
        public bool IsSSD { get; set; }
        public bool IsHDD { get; set; }

    }

    public class HardDiscCapacityPostDtoValidator : AbstractValidator<HardDiscCapacityPostDto>
    {
        public HardDiscCapacityPostDtoValidator()
        {
            RuleFor(x => x.Capacity).MaximumLength(50).NotEmpty().WithMessage("capacity is required");
            RuleFor(x => x.CycleRate).NotEmpty().WithMessage("cycle rate is required");
        }
    }
}
