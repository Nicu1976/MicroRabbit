﻿using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroRabbit.Transfer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        // GET: api/transferlogs
        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}
