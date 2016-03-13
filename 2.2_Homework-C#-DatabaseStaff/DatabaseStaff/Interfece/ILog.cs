using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseStaff
{
    interface ILog
    {
        void LogSave(object entity);
        object LogOut();
    }
}
