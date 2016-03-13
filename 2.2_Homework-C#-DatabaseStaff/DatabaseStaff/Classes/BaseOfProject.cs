using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseStaff
{
    class BaseOfProject
    {
        private IOperation operation;
        private IReadFile read;
        private ICheckFile check;
        private IDrowTable draw;
        public void ToProject()
        {
            operation = new Operations();
            read = new LogRead();
            check = new CheckFile();
            draw = new DrawTableResults();
            new Menu().Show(operation, read, check, draw);
        }
    }
}
