using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Oqtane.Models;
using Oqtane.Security;
using Oqtane.Shared;
using [Owner].Module.[Module].Repository;

namespace [Owner].Module.[Module].Services
{
    public class Server[Module]Service : I[Module]Service
    {
        private readonly I[Module]Repository _[Module]Repository;
        private readonly IUserPermissions _userPermissions;
        private readonly ILogManager _logger;
        private readonly IHttpContextAccessor _accessor;
        private readonly Alias _alias;

        public Server[Module]Service(I[Module]Repository [Module]Repository, IUserPermissions userPermissions, ITenantManager tenantManager, ILogManager logger, IHttpContextAccessor accessor)
        {
            _[Module]Repository = [Module]Repository;
            _userPermissions = userPermissions;
            _logger = logger;
            _accessor = accessor;
            _alias = tenantManager.GetAlias();
        }

        public Task<List<Models.[Module]>> Get[Module]sAsync(int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.View))
            {
                return Task.FromResult(_[Module]Repository.Get[Module]s(ModuleId).ToList());
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized [Module] Get Attempt {ModuleId}", ModuleId);
                return null;
            }
        }

        public Task<Models.[Module]> Get[Module]Async(int [Module]Id, int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.View))
            {
                return Task.FromResult(_[Module]Repository.Get[Module]([Module]Id));
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized [Module] Get Attempt {[Module]Id} {ModuleId}", [Module]Id, ModuleId);
                return null;
            }
        }

        public Task<Models.[Module]> Add[Module]Async(Models.[Module] [Module])
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, [Module].ModuleId, PermissionNames.Edit))
            {
                [Module] = _[Module]Repository.Add[Module]([Module]);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "[Module] Added {[Module]}", [Module]);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized [Module] Add Attempt {[Module]}", [Module]);
                [Module] = null;
            }
            return Task.FromResult([Module]);
        }

        public Task<Models.[Module]> Update[Module]Async(Models.[Module] [Module])
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, [Module].ModuleId, PermissionNames.Edit))
            {
                [Module] = _[Module]Repository.Update[Module]([Module]);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "[Module] Updated {[Module]}", [Module]);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized [Module] Update Attempt {[Module]}", [Module]);
                [Module] = null;
            }
            return Task.FromResult([Module]);
        }

        public Task Delete[Module]Async(int [Module]Id, int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.Edit))
            {
                _[Module]Repository.Delete[Module]([Module]Id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "[Module] Deleted {[Module]Id}", [Module]Id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized [Module] Delete Attempt {[Module]Id} {ModuleId}", [Module]Id, ModuleId);
            }
            return Task.CompletedTask;
        }
    }
}
