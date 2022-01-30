using WeeloApi.Application.Common.Interfaces;
using System;

namespace WeeloApi.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
