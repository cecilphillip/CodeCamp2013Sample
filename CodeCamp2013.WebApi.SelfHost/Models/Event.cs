﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CodeCamp2013.WebApi.SelfHost.Models
{
    public class Event
    {
        [Key]
        public int ID { get; set; }
        public string Host { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Address { get; set; }
    }
}
