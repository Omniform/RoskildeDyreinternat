using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public interface IEventHandler
    {
        public static abstract void Add();
        public static abstract void Remove();
        public static abstract void Update();
    }
}
