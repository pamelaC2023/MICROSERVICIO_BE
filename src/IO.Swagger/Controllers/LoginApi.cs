/*
 * API Authentication
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Attributes;

using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using IO.Swagger.Services;
using System.Net;
using IO.Swagger.Models;
using IO.Swagger.Models.DTO;

namespace IO.Swagger.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private readonly MongoDBServices _mongoDBServices;

        protected RespuestAPI _respuestaApi;

        public LoginApiController(MongoDBServices mongoDBServices)
        {
            _mongoDBServices = mongoDBServices;
            this._respuestaApi = new();
        }

        
        /// <summary>
        /// Change
        /// </summary>
        /// <remarks>Cambio de clave.</remarks>
        /// <param name="body">Cambio de clave</param>
        /// <response code="200">Cambio de clave exitoso</response>
        /// <response code="404">Usuario no encontrado o clave incorrecta</response>
        /// <response code="500">Error de Cambio de clave</response>
        [HttpPost]
        [Route("/rest/authentication-api/v1.0/login/change-password")]
        [ValidateModelState]
        [SwaggerOperation("LoginChangePasswordPost")]
        public virtual IActionResult LoginChangePasswordPost([FromBody]RequestChangePassword body)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Authentication
        /// </summary>
        /// <remarks>Autenticacion de usuario.</remarks>
        /// <param name="body">Usuario a ser creado</param>
        /// <response code="200">Inicio de sesión exitoso</response>
        /// <response code="404">Credenciales no existentes</response>
        /// <response code="500">Error de inicio de sesión </response>
        [HttpPost]
        [Route("/rest/authentication-api/v1.0/login")]
        [ValidateModelState]
        [SwaggerOperation("LoginPost")]
        public async Task<IActionResult> LoginPost([FromBody]RequestLogin body)
        { 
            var respuestaLogin = await _mongoDBServices.Login(body);

            if(respuestaLogin == null || respuestaLogin.Users == null || string.IsNullOrEmpty(respuestaLogin.Token))
            {
                _respuestaApi.StatusCode = HttpStatusCode.NotFound;
                _respuestaApi.IsSucces = false;
                _respuestaApi.ErrorMessages.Add("El nombre de usuario o password inexistentes");
                return BadRequest(_respuestaApi);

            }

            _respuestaApi.StatusCode=HttpStatusCode.OK;
            _respuestaApi.IsSucces=true;
            _respuestaApi.Result = respuestaLogin;
            return Ok(_respuestaApi);
        }

        /// <summary>
        /// Recovery
        /// </summary>
        /// <remarks>Recuperacion de usuario.</remarks>
        /// <param name="body">Recuperación de clave</param>
        /// <response code="200">Recuperación de clave exitoso, fue enviada a tu correo</response>
        /// <response code="404">Usuario no encontrado</response>
        /// <response code="500">Error de recuperar clave</response>
        [HttpPost]
        [Route("/rest/authentication-api/v1.0/login/recovery-password")]
        [ValidateModelState]
        [SwaggerOperation("LoginRecoveryPasswordPost")]
        public virtual IActionResult LoginRecoveryPasswordPost([FromBody]RequestRecoveryPassword body)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500);

            throw new NotImplementedException();
        }
    }
}
