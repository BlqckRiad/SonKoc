﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.DtoLayer.Dtos
{
    public class DeleteDto
    {
        public int TabloID { get; set; }
        public int SilenKisiID { get; set; }
        public string Token { get; set; }
    }
}
