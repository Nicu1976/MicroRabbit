using MicroRabbit.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Domain.Core.Bus
{
    public interface IMediatorBus
    {
        Task SendCommand<T>(T command) where T : Command;
    }
}
