using ControllerSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private IVideoService videoService;

        public VideoController(IVideoService videoService)
        {
            this.videoService = videoService;
        }

        //QueryString = PArameter über URL an WebAPI Methode(Action-Methoden) übergeben 
        [HttpGet("{name}")]
        public async Task<ActionResult> Index(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            Stream stream = await videoService.GetVideoByName(name);
            return new FileStreamResult(stream, "video/mp4");
        }

    }
}
