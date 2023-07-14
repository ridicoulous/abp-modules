﻿using System;

namespace Passingwind.Abp.FileManagement.Files;

public class FileDownloadInfoResultDto
{
    public string FileName { get; set; } = null!;
    public long Length { get; set; }
    public string DownloadUrl { get; set; } = null!;
    public string Token { get; set; } = null!;
    public DateTime? ExpirationTime { get; set; }
}
