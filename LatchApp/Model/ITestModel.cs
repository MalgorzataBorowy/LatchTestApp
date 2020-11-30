﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatchApp.Model
{
    interface ITestModel:IModel
    {
        int LatchID { get; set; }
        DateTime EndTime { get; set; }
        DateTime Date { get; set; }
        bool Status { get; set; }
        int Cycles { get; set; }
        string VideoLink { get; set; }
        string Comments { get; set; }
    }
}
