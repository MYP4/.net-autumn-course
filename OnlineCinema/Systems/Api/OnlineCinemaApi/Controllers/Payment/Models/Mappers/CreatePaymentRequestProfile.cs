using AutoMapper;
using OnlineCinema.Api.Controllers.Genre.Models;
using OnlineCinema.BL.Entities.Genres.Entities;
using OnlineCinema.BL.Payments.Entity;

namespace OnlineCinema.Api.Controllers.Payment.Models.Mappers;

public class CreatePaymentRequestProfile : Profile
{
    public CreatePaymentRequestProfile()
    {
        CreateMap<CreatePaymentRequestProfile, CreatePaymentModel>();
    }
}
