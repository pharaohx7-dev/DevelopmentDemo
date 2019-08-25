using DevelopmentWebApi.Desarrollo.AppServices;
using DevelopmentWebApi.Desarrollo.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevelopmentWebApi.Desarrollo.Controllers
{
    [Route("projects")]
    public class ProjectsController : Controller
    {
        private readonly ProjectsAppService _projectsAppService;

        public ProjectsController(ProjectsAppService projectsAppService)
        {
            _projectsAppService = projectsAppService;
        }

        [HttpGet("apiConnectionTest")]
        public IActionResult ApiConnectionTest()
        {
            var response = _projectsAppService.ApiConnectionTest();
            return Ok(response);
        }

        [HttpGet("getCurrentSprint")]
        public async Task<IActionResult> GetCurrentSprint()
        {
            var response = await _projectsAppService.GetCurrentSprint();
            return Ok(response);
        }

        [HttpGet("getTaskTypes")]
        public async Task<IActionResult> GetTaskTypes()
        {
            var response = await _projectsAppService.GetTaskTypes();
            return Ok(response);
        }

        [HttpGet("sprintRequirementsByDeveloper")]
        public async Task<IActionResult> GetSprintRequirementsByDeveloper()
        {
            var response = await _projectsAppService.GetSprintRequirementsByDeveloper();
            return Ok(response);
        }

        [HttpPost("saveSprintTrack")]
        public async Task<IActionResult> SaveSprintTrack([FromQuery] int sprintDetailId)
        {
            var response = await _projectsAppService.SaveSprintTrack(sprintDetailId);
            return Ok(response);
        }

        [HttpPut("endSprintTrack")]
        public async Task<IActionResult> EndSprintTrack([FromQuery] int sprintTrackId)
        {
            var response = await _projectsAppService.EndSprintTrack(sprintTrackId);
            return Ok(response);
        }

        [HttpPost("saveTask")]
        public async Task<IActionResult> SaveTask([FromBody] NewTaskDto newTaskDto)
        {
            var response = await _projectsAppService.SaveTask(newTaskDto);
            return Ok(response);
        }

        [HttpPut("completePendingTask")]
        public async Task<IActionResult> CompletePendingTask([FromQuery] int taskId)
        {
            var response = await _projectsAppService.CompletePendingTask(taskId);
            return Ok(response);
        }
    }
}
