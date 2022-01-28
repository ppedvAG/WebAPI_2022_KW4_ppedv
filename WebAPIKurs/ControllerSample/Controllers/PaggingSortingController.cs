using ControllerSample.Data;
using ControllerSample.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControllerSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaggingSortingController : ControllerBase
    {
        private readonly MovieDbContext context;

        public PaggingSortingController(MovieDbContext context)
        {
            this.context = context;
        }

        [HttpGet("EasyPaggingList")]
        public async Task<ActionResult<IEnumerable<Movie>>> PaggingSample1 (int pageNumber=1, int pageSize=3)
        {
            return await context.Movie.OrderBy(o => o.Title)
                                      .Skip((pageNumber - 1) * pageSize)
                                      .Take(pageSize).ToListAsync();
        }


        [HttpGet("WithPageParameterObj")]
        public async Task<ActionResult<IEnumerable<Movie>>> PaggingSample2([FromQuery] PageParameter parameter)
        {
            return await context.Movie.OrderBy(o => o.Title)
                                      .Skip((parameter.PageNumber - 1) * parameter.PageSize)
                                      .Take(parameter.PageSize).ToListAsync();
        }

    }

    public class PageParameter
    {
        const int maxPageSize = 5;

        
        public int PageNumber { get; set; } = 1;
        private int pageSize = 3;

        public int PageSize
        {
            get
            {
                return pageSize;
            }

            set
            {
                pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

    }
}
