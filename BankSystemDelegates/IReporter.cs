﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDelegates
{
    public interface IReporter
    {
        void SendReport(string message);
    }
}
