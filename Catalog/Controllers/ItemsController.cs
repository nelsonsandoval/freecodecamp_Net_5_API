using Catalog.Repositories;
using Catalog.Entities;
using Catalog.Dtos;
using Catalog;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Calalog.Controllers{
    [ApiController]
    [Route("items")]
    public class ItemsController: ControllerBase{
        private readonly IItemsRepository repository;

        public ItemsController( IItemsRepository repository ){
            this.repository = repository;
        }

    
        [HttpGet]
        public IEnumerable<ItemDto> GetItems(){
            var items = repository.GetItems().Select( item => item.AsDto() );
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id){
            var item = repository.GetItem(id);
            if (item is null){
                return NotFound();
            }
            return item.AsDto();
        }

    }
}