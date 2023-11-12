﻿using System.ComponentModel.DataAnnotations;

namespace OnlineCinema.Contex.Entities;

public class BaseEntity
{
    public int Id { get; set; }

    public Guid ExternalId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }

}