using WeeloApi.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeloApi.Application.Common.Abstracts
{
    public abstract class CommandRequest<TData> : IRequest<CommandResult<TData>>
    {
    }
}
