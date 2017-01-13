using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace CoreWEBAPI.Domain.DTOs
{
    public class BaseDto
    {
        [Range(0,0)]
        public int Id { get; set; }
    }
}