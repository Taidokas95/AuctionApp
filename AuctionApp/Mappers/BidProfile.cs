using AuctionApp.Core;
using AuctionApp.Persistence;
using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace AuctionApp.Mappers;

public class BidProfile : Profile
{
    public BidProfile()
    {
        CreateMap<BidDb, Bid>().ReverseMap();
    }
}