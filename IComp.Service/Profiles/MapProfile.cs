using AutoMapper;
using IComp.Core.Entities;
using IComp.Service.DTOs.BrandDTOs;
using IComp.Service.DTOs.CategoryDTOs;
using IComp.Service.DTOs.ColorDTOs;
using IComp.Service.DTOs.DestinationDTOs;
using IComp.Service.DTOs.HardDiscCapacityDTOs;
using IComp.Service.DTOs.HardDiscDTOs;
using IComp.Service.DTOs.MemoryCapacityDTOs;
using IComp.Service.DTOs.MemoryDTOs;
using IComp.Service.DTOs.MotherBoardDTOs;
using IComp.Service.DTOs.ProcessorDTOs;
using IComp.Service.DTOs.ProcessorSerieDTOs;
using IComp.Service.DTOs.ProdTypeDTOs;
using IComp.Service.DTOs.ProductDTOs;
using IComp.Service.DTOs.ProductPartsDTOs;
using IComp.Service.DTOs.SoftwareDTOs;
using IComp.Service.DTOs.VCSerieDTOs;
using IComp.Service.DTOs.VideoCardDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProcessorSerie, ProcessorSerieGetDto>();
            CreateMap<ProcessorPostDTO, Processor>();
            CreateMap<Processor, ProcessorPostDTO>();
            CreateMap<Processor, ProcessorGetDto>();
            CreateMap<ProcessorSeriePostDto, ProcessorSerie>();
            CreateMap<ProcessorSerie, ProcessorSeriePostDto>();
            CreateMap<VideoCardPostDto, VideoCard>();
            CreateMap<VideoCard, VideoCardPostDto>();
            CreateMap<VideoCard, VideoCardGetDto>();

            CreateMap<ProdType, ProdTypeGetDto>();

            CreateMap<Destination, DestinationGetDto>();

            CreateMap<VideoCardSerie, VCSerieGetDto>();
            CreateMap<VCSeriePostDto, VideoCardSerie>();
            CreateMap<ProdMemory, MemoryPostDto>();
            CreateMap<ProdMemory, MemoryGetDto>();
            CreateMap<MemoryCapacity, MCapacityGetDto>();
            CreateMap<MemoryCapacity, MCapacityPostDto>();
            CreateMap<MCapacityPostDto, MemoryCapacity>();
            CreateMap<MemoryPostDto, ProdMemory>();
            CreateMap<HDDCapacity, HardDiscCapacityGetDto>();
            CreateMap<HardDiscPostDto, HardDisc>();
            CreateMap<HardDisc, HardDiscPostDto>();
            CreateMap<HardDisc, HardDiscGetDto>();
            CreateMap<HardDiscCapacityPostDto, HDDCapacity>();
            CreateMap<HDDCapacity, HardDiscCapacityPostDto>();
            CreateMap<BrandPostDto, Brand>();
            CreateMap<Brand, BrandPostDto>();
            CreateMap<Brand, BrandGetDto>();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<Category, CategoryPostDto>();
            CreateMap<Category, CategoryGetDto>();
            
            CreateMap<MotherBoardPostDto, MotherBoard>();
            CreateMap<MotherBoard, MotherBoardPostDto>();
            CreateMap<MotherBoard, MotherBoardGetDto>();

            CreateMap<ProductPostDto, Product>();
            CreateMap<Product, ProductPostDto>();
            CreateMap<Product, ProductGetDTO>();

            CreateMap<Color, ColorGetDto>();
            CreateMap<Software, SoftwareGetDto>();

            CreateMap<ProdProcessorPostDto, ProductPostDto>();
            CreateMap<ProdVideoCardDto, ProductPostDto>();
            CreateMap<ProdMotherBoardDto, ProductPostDto>();
            CreateMap<ProdRamDto, ProductPostDto>();
            CreateMap<ProdCoolerDto, ProductPostDto>();
            CreateMap<ProdSSDDto, ProductPostDto>();
            CreateMap<ProdHddDto, ProductPostDto>();
            CreateMap<Product, ProductListItemDto>();
        }
    }
}
