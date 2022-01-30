
using WeeloApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace WeeloApi.Application.Common.Interfaces
{
    public interface IApplicationDbContext : IBaseDbContext
    {
        DbSet<Owner> Owners { get; set; }
        DbSet<PropertyTrace> PropertyTraces { get; set; }
        DbSet<PropertyImage> PropertyImages { get; set; }
        DbSet<Property> Propertys { get; set; }

        new Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
