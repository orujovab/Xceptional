using FluentValidation;
using IComp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.VideoCardDTOs
{
    public class VideoCardPostDto
    {
        public string ModelName { get; set; }
        public int VideoCardSerieId { get; set; }
        public bool IsAvailable { get; set; }
        public string MemoryCapacity { get; set; }
        public string CoreSpeed { get; set; }
        public VideoCardSerie VideoCardSerie { get; set; }
        public List<Product> Products { get; set; }
    }

    public class VideoCardPostDtoValidator : AbstractValidator<VideoCardPostDto>
    {
        public VideoCardPostDtoValidator()
        {
            RuleFor(x => x.ModelName).MaximumLength(50).NotEmpty().WithMessage("model is required");
            RuleFor(x => x.CoreSpeed).MaximumLength(50).NotEmpty().WithMessage("CoreSpeed is required");
            RuleFor(x => x.MemoryCapacity).NotEmpty().WithMessage("memorycapacity is required");
        }
    }
}
