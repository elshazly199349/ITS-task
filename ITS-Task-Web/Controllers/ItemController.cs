using DomainModels.DTOs;
using InterfacesLayer.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace ITS_Task_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemManager _itemManager;
        private readonly IStepManager _stepManager;
        public ItemController(IItemManager itemManager,IStepManager stepManager) {
            _itemManager = itemManager;
            _stepManager = stepManager;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var items = _itemManager.GetAllDTO<ItemDto>();
            return Ok(items);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            //ModelState.AddModelError("error", "xysdfdg");
            //return BadRequest(ModelState);
            var item = _itemManager.GetByIdDTO<ItemDto>(id);
            return Ok(item);
        }

        [HttpGet]
        [Route("GetByStepId/{stepId}")]
        public IActionResult GetByStepId(int stepId)
        {
            var items = _itemManager.FindDTO<ItemDto>(e => e.StepId == stepId);
            return Ok(items);
        }

        [HttpPost]
        public IActionResult Create([FromBody]ItemDto model) {
            if (ModelState.IsValid)
            {
                var step = _stepManager.GetById(model.StepId);
                if (step==null)
                {
                    return NotFound($"Step with Id:{model.StepId} not found");
                }
                model= _itemManager.AddDTO<ItemDto>(model);
                _itemManager.SaveChanges();
                return Ok(model);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody]ItemDto model) {
            if (ModelState.IsValid)
            {
                var item = _itemManager.GetById(model.Id);
                if (item == null)
                    return NotFound($"item with Id:{model.Id} not found");
                var step = _stepManager.GetById(model.StepId);
                if (step == null)
                    return NotFound($"Step with Id:{model.StepId} not found");
                
                model = _itemManager.UpdateDTO<ItemDto>(model);
                _itemManager.SaveChanges();
                return Ok(model);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id) {
            _itemManager.Remove(id);
            _itemManager.SaveChanges();
            return Ok();
        }
    }
}