using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using $ext_safeprojectname$.API.DataContracts.Requests;
using $ext_safeprojectname$.API.DataContracts;
using $ext_safeprojectname$.Services;
using AutoMapper;
using S = $ext_safeprojectname$.Services.Model;
using $ext_safeprojectname$.Services.Contracts;

namespace DotNetCore.API1.Controllers
{
    [Route("api/v1.0/users")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #region GET
        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            var data = await _service.GetAsync(id);

            if (data != null)
                return _mapper.Map<User>(data);
            else
                return null;
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<User> CreateUser([FromBody]UserCreationRequest value)
        {

            //TODO: include exception management policy according to technical specifications
            if (value == null)
                throw new ArgumentNullException("value");


            var data = await _service.CreateAsync(Mapper.Map<S.User>(value));

            if (data != null)
                return _mapper.Map<User>(data);
            else
                return null;

        }
        #endregion

        #region PUT
        [HttpPut()]
        public async Task<bool> UpdateUser(User parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException("parameter");

            return await _service.UpdateAsync(Mapper.Map<S.User>(parameter));            
        }        
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<bool> DeleteDevice(string id)
        {
            return await _service.DeleteAsync(id);
        }
        #endregion
    }
}
