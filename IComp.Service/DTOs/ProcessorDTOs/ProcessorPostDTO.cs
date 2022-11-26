using FluentValidation;
using IComp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.ProcessorDTOs
{
    public class ProcessorPostDTO
    {
        public int ProcessorSerieId { get; set; }
        public string ModelName { get; set; }
        public string Speed { get; set; }
        public int CoreCount { get; set; }
        public bool IsAvailable { get; set; }
        public ProcessorSerie ProcessorSerie { get; set; }
        public List<Product> Products { get; set; }
    }

    public class ProcessorPostDTOValidator : AbstractValidator<ProcessorPostDTO>
    {
        public ProcessorPostDTOValidator()
        {
            RuleFor(x => x.ModelName).MaximumLength(50).NotEmpty().WithMessage("model is required");
            RuleFor(x => x.Speed).MaximumLength(50).NotEmpty().WithMessage("processor speed is required");
            RuleFor(x => x.CoreCount).NotEmpty().WithMessage("processor corecount is required");
        }
    }
}
