using WeeloApi.Domain.Common;
using System.Threading.Tasks;

namespace WeeloApi.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
