﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCMSLibrary.Entities;

namespace DnDCMS.ViewModel
{
    public class ClassViewModel
    {
        public List<Class> Class { get; set; }

        public Class SelectedClass { get; set; }
    }
}
