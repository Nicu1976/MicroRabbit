using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        //private readonly IEventBus _bus;
        private readonly IMediatorBus _mediator;

        //public AccountService(IAccountRepository accountRepository, IEventBus bus, IMediatorBus mediator)
        public AccountService(IAccountRepository accountRepository, IMediatorBus mediator)
        {
            _accountRepository = accountRepository;
            //_bus = bus;
            _mediator = mediator; 
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();            
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.FromAccount, 
                accountTransfer.ToAccount, 
                accountTransfer.TransferAmount);

            //_bus.SendCommand(createTransferCommand);
            _mediator.SendCommand(createTransferCommand);
        }
    }
}
