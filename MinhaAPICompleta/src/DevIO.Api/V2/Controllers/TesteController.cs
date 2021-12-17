﻿using DevIO.Api.Controller;
using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevIO.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteController : MainController
    {
        private readonly ILogger _logger;
        public TesteController(INotificador notificador, IUser user, ILogger<TesteController> logger) : base(notificador, user)
        {
            _logger = logger;
        }

        [HttpGet()]
        public string Valor()
        {
            _logger.LogTrace("Log de Trace");
            _logger.LogDebug("Log de Debug");
            _logger.LogInformation("Log de Informação");
            _logger.LogWarning("Log de Aviso");
            _logger.LogError("Log de Erro");
            _logger.LogCritical("Log de Problema Critico");


            return "Sou a V2";
        }

    }
}
