using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Core
{
    public interface IUnitOfWork
    {
        IProcessorRepository ProcessorRepository { get; }
        IProcessorSerieRepository ProcessorSerieRepository { get; }
        IVideoCardRepository VideoCardRepository { get; }
        IVCSerieRepository VCSerieRepository { get; }
        IMemoryRepository MemoryRepository { get; }
        IMemoryCapacityRepository MemoryCapacityRepository { get; }
        IMotherBoardRepository MotherBoardRepository { get; }
        IHardDiscRepository HardDiscRepository { get; }
        IHardDiscCapacityRepository HardDiscCapacityRepository { get; }
        IBrandRepository BrandRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IProdTypeRepository ProdTypeRepository { get; }
        IDestinationRepository DestinationRepository { get; }
        IColorRepository ColorRepository { get; }
        ISoftWareRepository SoftWareRepository { get; }
        IProductImageRepository ProductImageRepository { get; }
        ISettingRepository SettingRepository { get; }
        IBasketItemRepository BasketItemRepository { get; }
        IProductCommentRepository ProductCommentRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        ISSDCapacityRepository SSDCapacityRepository { get; }
        ISSDRepository SSDRepository { get; }
        ISliderRepository SliderRepository { get; }
        ICheckedProductsRepository CheckedProductsRepository { get; }
        IAppUserRepository AppUserRepository { get; }
        IFeedBackRepository FeedBackRepository { get; }

        int Commit();
        Task<int> CommitAsync();
    }
}
