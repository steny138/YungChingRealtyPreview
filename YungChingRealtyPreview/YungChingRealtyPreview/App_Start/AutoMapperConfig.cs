using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YungChingRealtyPreview.ViewModel;
using YungChingRealtyPreview.Repository;

namespace YungChingRealtyPreview
{
	public class AutoMapperConfig
	{
		public static MapperConfiguration Bootstrap()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<OrganizationProfile>();
			});

			return config;
		}
	}

	public class OrganizationProfile : Profile
	{
		
		public OrganizationProfile()
		{
			CreateMap<Products, ProductViewModel>();
		}
	}
}