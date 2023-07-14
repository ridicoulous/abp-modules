﻿using System.ComponentModel.DataAnnotations;

namespace Passingwind.Abp.FileManagement.Files;

public class FileUpdateDto
{
    [Required]
    [MaxLength(128)]
    public string FileName { get; set; } = null!;

}
