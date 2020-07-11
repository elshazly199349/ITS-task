using System;
using BussinessLogicLayer.Intefaces;
using DomainModels.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ITS_Task_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {
        private readonly IStepManager _stepManager;
        public StepController(IStepManager stepManager)
        {
            _stepManager = stepManager;
        }

        [HttpGet]
        public IActionResult GetAll() {
            try
            {
                var steps = _stepManager.GetAllDTO<StepDto>();
                return Ok(steps);
            }
            catch (Exception e)
            {
                return Problem(e.Message,e.InnerException.Message, null);
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var step = _stepManager.GetByIdDTO<StepDto>(id);
            if (step == null)
            {
                return NotFound();
            }
            return Ok(step);
        }

        [HttpPut]
        public IActionResult Update([FromBody] StepDto model) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var step = _stepManager.GetById(model.Id);
                if (step == null)
                    return NotFound($"there is no step with id: {model.Id}");
                _stepManager.UpdateDTO<StepDto>(model);
                _stepManager.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id) {
            _stepManager.Remove(id);
            _stepManager.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(StepDto model) {
            if (ModelState.IsValid)
            {
                _stepManager.AddDTO<StepDto>(model);
                _stepManager.SaveChanges();
                return Ok();
            }
            return BadRequest("Error occured, try again");
        }
    }
}