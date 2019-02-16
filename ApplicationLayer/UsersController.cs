﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GFStore.BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GFStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserBol _userBol;
      
        public UsersController(IUserBol userBol)
        {
            _userBol = userBol;
        }
        // GET
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_userBol.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_userBol.GetById(id));
        }

        
    }
}
