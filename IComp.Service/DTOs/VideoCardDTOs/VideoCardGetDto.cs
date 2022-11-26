﻿using System;
using System.Collections.Generic;
using System.Text;
using IComp.Service.DTOs.ProductDTOs;

namespace IComp.Service.DTOs.VideoCardDTOs
{
    public class VideoCardGetDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public bool IsDeleted { get; set; }
        public List<ProductGetDTO> Products { get; set; }
    }
}
