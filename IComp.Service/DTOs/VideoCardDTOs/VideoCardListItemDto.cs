using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.VideoCardDTOs
{
    public class VideoCardListItemDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int ProductsCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
