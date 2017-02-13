using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Dal;
using TaskApp.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskApp.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {

        private ITaskAppRepository _repository;

        public TaskController(ITaskAppRepository repository)
        {
            _repository = repository;
        }

        // GET: api/values
        [HttpGet]
        public Task Get()
        {
            return _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Task Get(int id)
        {
            return _repository.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post(Task value)
        {
            _repository.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(Task task)
        {
            _repository.Update(task);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
