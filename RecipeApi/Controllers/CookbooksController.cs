using Microsoft.AspNetCore.Mvc;
using RecipeApi.Interfaces;
using RecipeApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CookbooksController : ControllerBase
    {
        private readonly IRepository _repository;
        public CookbooksController(AppDBContext context, IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cookbook>>> GetCookbook(int page = 0, int pageSize = 5)
        {
            var model = await _repository.SelectAll<Cookbook>();
            return model;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Cookbook>>> GetCookbook(Guid userId)
        {
            var model = await _repository.SelectAll<Cookbook>();

            if (model == null)
            {
                return NotFound();
            }

            var cookbooks = new List<Cookbook>();
            foreach (var cookbook in model)
            {
                if (cookbook.UserId == userId)
                {
                    cookbooks.Add(cookbook);
                }
            }

            return cookbooks;
        }

        [HttpPut("{cookbookId}")]
        public async Task<IActionResult> UpdateCookbook(Guid cookbookId, Cookbook model)
        {
            if (cookbookId != model.CookbookId)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync<Cookbook>(model);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Cookbook>> InsertCookbook(Cookbook model)
        {
            model.CookbookId = Guid.NewGuid();
            var currentTime = DateTime.Now;
            model.CreatedOn = currentTime;
            model.ModifiedOn = currentTime;
            model.IsActive = true;
            await _repository.CreateAsync<Cookbook>(model);
            return CreatedAtAction("GetCookbook", new { cookbookId = model.CookbookId }, model);
        }

        [HttpDelete("{cookbookId}")]
        public async Task<ActionResult<Cookbook>> DeleteCookbook(Guid cookbookId)
        {
            var model = await _repository.SelectById<Cookbook>(cookbookId);

            if (model == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync<Cookbook>(model);

            return NoContent();
        }
    }
}
