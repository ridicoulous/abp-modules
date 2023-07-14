﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Passingwind.Abp.FileManagement.Files;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Passingwind.Abp.FileManagement.EntityFrameworkCore.Repositories;

public class FileRepository : EfCoreRepository<FileManagementDbContext, File, Guid>, IFileRepository
{
    public FileRepository(IDbContextProvider<FileManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public virtual async Task<long> GetCountAsync(string? filter, Guid? containerId, Guid? parentId, CancellationToken cancellationToken = default)
    {
        var dbset = await GetDbSetAsync();
        return await dbset
            .WhereIf(!string.IsNullOrEmpty(filter), x => x.FileName.Contains(filter!))
            .WhereIf(containerId.HasValue, x => x.ContainerId == containerId)
            .WhereIf(parentId.HasValue, x => x.ParentId == parentId)
            .LongCountAsync(cancellationToken);
    }

    public virtual async Task<List<File>> GetListAsync(string? filter, Guid? containerId, Guid? parentId, bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        var dbset = await GetDbSetAsync();
        return await dbset
            .WhereIf(!string.IsNullOrEmpty(filter), x => x.FileName.Contains(filter!))
            .WhereIf(containerId.HasValue, x => x.ContainerId == containerId)
            .WhereIf(parentId.HasValue, x => x.ParentId == parentId)
            .ToListAsync(cancellationToken);
    }

    public virtual async Task<List<File>> GetPagedListAsync(int skipCount, int maxResultCount, string? filter, Guid? containerId, Guid? parentId, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        var dbset = await GetDbSetAsync();
        return await dbset
            .WhereIf(!string.IsNullOrEmpty(filter), x => x.FileName.Contains(filter!))
            .WhereIf(containerId.HasValue, x => x.ContainerId == containerId)
            .WhereIf(parentId.HasValue, x => x.ParentId == parentId)
            .PageBy(skipCount, maxResultCount)
            .OrderBy(sorting ?? nameof(File.CreationTime) + " desc")
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsFileNameExistsAsync(Guid containerId, string fileName, Guid? parentId, CancellationToken cancellationToken = default)
    {
        var dbset = await GetDbSetAsync();
        return await dbset
            .WhereIf(parentId.HasValue, x => x.ParentId == parentId)
            .Where(x => x.ContainerId == containerId && x.FileName == fileName)
            .AnyAsync(cancellationToken);
    }
}