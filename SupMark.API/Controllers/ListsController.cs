using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupMark.Core.DTOs;
using SupMark.Core.Entities;
using SupMark.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupMark.API.Controllers
{
    public class ListsController : BaseController
    {
        public readonly IListService _listService;
        public readonly IUserService _userService;
        public readonly IItemService _itemService;
        public ListsController(IListService listService,
            IUserService userService,
            IItemService itemService)
        {
            _listService = listService;
            _userService = userService;
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<List>>> Index()
        {
            var lists = await _listService.FetchLists();

            return Ok(lists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List>> Index([FromRoute] int id)
        {
            var list = await _listService.FetchList(id);

            return Ok(list);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] ListDto listDto)
        {
            var users = await _userService.FetchUsers(listDto?.UserIds);
            var items = await _itemService.FetchItems(listDto?.ItemIds);

            var list = new List(listDto.Name, users, items, listDto.Notes);

            await _listService.CreateList(list);

            return NoContent();
        }

        [HttpPatch("[action]/{id}")]
        public async Task<ActionResult<List>> Update([FromRoute] int id, [FromBody] ListDto listDto)
        {
            var users = await _userService.FetchUsers(listDto.UserIds);
            var items = await _itemService.FetchItems(listDto.ItemIds);

            var list = new List(listDto.Name, users, items, listDto.Notes);

            var model = await _listService.UpdateList(id, list);

            if (model == null) return BadRequest();

            return NoContent();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _listService.DeleteList(id);

            if (!result) return BadRequest();

            return NoContent();
        }
    }
}
