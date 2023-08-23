﻿using System;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.PermissionManagement;

namespace Passingwind.Abp.DynamicPermissionManagement.Permissions;

public interface IPermissionGroupDefinitionRecordRepository : IRepository<PermissionGroupDefinitionRecord, Guid>
{
}
