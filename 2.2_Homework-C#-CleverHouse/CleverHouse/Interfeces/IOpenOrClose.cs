using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public interface IOpenOrClose
    {
            bool StatusOpen { get; set; }
            void Open();
            void Close();
        }
    
}
