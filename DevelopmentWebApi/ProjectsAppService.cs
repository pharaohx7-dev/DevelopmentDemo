using DevelopmentInfrastructure;
using DevelopmentWebApi._Common.Dtos;
using DevelopmentWebApi.Desarrollo.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentWebApi.Desarrollo.AppServices
{
    public class ProjectsAppService
    {
        private readonly DevelopmentContext _context;

        public ProjectsAppService(DevelopmentContext context)
        {
            _context = context;
        }

        internal string ApiConnectionTest()
        {
            return "Si hay conexion al api!";
        }

        internal async Task<CurrentSprintDto> GetCurrentSprint()
        {
            var sprint = await (from s in _context.Sprint.AsQueryable().AsNoTracking()
                                where DateTime.Now.Date >= s.StartDate.Date &&
                                      DateTime.Now.Date <= s.EndDate.Date
                                //s.TeamId == 1
                                select new CurrentSprintDto
                                {
                                    SprintId = s.Id,
                                    SprintName = s.Name,
                                    SprintStartDate = s.StartDate,
                                    SprintEndDate = s.EndDate
                                }).FirstOrDefaultAsync();

            return sprint;
        }

        internal async Task<List<StandardDto>> GetTaskTypes()
        {
            var types = await (from tt in _context.TaskType.AsQueryable().AsNoTracking()
                               where tt.IsActive.Value
                               select new StandardDto
                               {
                                   Id = tt.Id,
                                   Description = tt.Description
                               }).ToListAsync();

            return types;
        }

        internal async Task<List<SprintByDeveloperDetailDto>> GetSprintRequirementsByDeveloper()
        {
            var requerimientos = await (from sd in _context.SprintDetail.AsQueryable().AsNoTracking()
                                        select new SprintByDeveloperDetailDto
                                        {
                                            SprintDetailId = sd.Id,
                                            ProjectName = sd.Requirement.Module.Project.Name,
                                            ProjectDescription = sd.Requirement.Module.Project.Description,
                                            ModuleName = sd.Requirement.Module.Name,
                                            ModuleDescription = sd.Requirement.Module.Description,
                                            RequirementName = sd.Requirement.Name,
                                            RequirementDescription = sd.Requirement.Description,
                                            RequirementEstimatedHours = sd.Requirement.EstimatedHours,
                                            RequirementWorkedHours = sd.Requirement.WorkedHours,
                                            Tasks = (from t in _context.Task.AsQueryable().AsNoTracking()
                                                     where !t.IsCompleted && sd.SprintTrack.Select(x => x.Id).Contains(t.SprintTrackId)
                                                     select new PendingTaskByDeveloperDto
                                                     {
                                                         SprintTrackId = t.SprintTrackId,
                                                         TaskId = t.Id,
                                                         Name = t.Name,
                                                         Type = t.TaskType.Name,
                                                         StartDate = t.CreateDate,
                                                     }).ToList()
                                        }).ToListAsync();

            return requerimientos;
        }

        internal async Task<int> SaveSprintTrack(int sprintDetailId)
        {
            var sprintTrack = new SprintTrack()
            {
                SprintDetailId = sprintDetailId,
                StartDate = DateTime.Now
            };

            await _context.SprintTrack.AddAsync(sprintTrack);
            await _context.SaveChangesAsync();
            return sprintTrack.Id;
        }

        internal async Task<List<SprintByDeveloperDetailDto>> EndSprintTrack(int sprintTrackId)
        {
            var sprintTrack = await (from st in _context.SprintTrack.AsQueryable()
                                     .Include(x => x.SprintDetail)
                                     where st.Id == sprintTrackId
                                     select st).FirstOrDefaultAsync();

            var requirement = await (from r in _context.Requirement.AsQueryable()
                                     where r.Id == sprintTrack.SprintDetail.RequirementId
                                     select r).FirstOrDefaultAsync();

            DateTime endDate = DateTime.Now;
            TimeSpan sprinTrackTimeWorked = (sprintTrack.StartDate - endDate);
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    requirement.WorkedHours += (sprinTrackTimeWorked.Minutes / 60);
                    sprintTrack.EndDate = endDate;
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }

            return await GetSprintRequirementsByDeveloper();
        }

        internal async Task<PendingTaskByDeveloperDto> SaveTask(NewTaskDto newTaskDto)
        {
            var task = new DevelopmentInfrastructure.Task()
            {
                SprintTrackId = newTaskDto.SprintTrackId,
                Name = newTaskDto.Name,
                TaskTypeId = newTaskDto.TaskTypeId,
                CreateDate = DateTime.Now,
                IsCompleted = false,
                MediaServerPath = ""
            };

            await _context.Task.AddAsync(task);
            await _context.SaveChangesAsync();

            var newTask = await (from t in _context.Task.AsQueryable().AsNoTracking()
                                 where t.Id == task.Id
                                 select new PendingTaskByDeveloperDto()
                                 {
                                     SprintTrackId = t.SprintTrackId,
                                     TaskId = t.Id,
                                     Name = t.Name,
                                     Type = t.TaskType.Name,
                                     StartDate = t.CreateDate,
                                 }).FirstOrDefaultAsync();

            return newTask;
        }

        internal async Task<List<PendingTaskByDeveloperDto>> CompletePendingTask(int taskId)
        {
            var task = await (from t in _context.Task.AsQueryable()
                              where t.Id == taskId
                              select t).FirstOrDefaultAsync();

            task.IsCompleted = true;
            task.CompletionDate = DateTime.Now;
            await _context.SaveChangesAsync();

            var pendingTasks = await (from t in _context.Task.AsQueryable().AsNoTracking()
                                      where !t.IsCompleted && t.SprintTrackId == task.SprintTrackId
                                      select new PendingTaskByDeveloperDto
                                      {
                                          SprintTrackId = t.SprintTrackId,
                                          TaskId = t.Id,
                                          Type = t.TaskType.Name,
                                          Name = t.Name,
                                          StartDate = t.CreateDate
                                      }).ToListAsync();

            return pendingTasks;
        }
    }
}
