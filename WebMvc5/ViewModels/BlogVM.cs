﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvc5.ViewModels
{
    public class BlogLiteVM
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public byte[] RowVersion { get; set; }

    }
}