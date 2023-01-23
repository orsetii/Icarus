using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veil.Services
{
    public class GlobalStateService
    {
        public bool IsTransmissionEnabled { get; set; }
        public bool DarkMode { get; set; }

        public GlobalStateService()
        {
            IsTransmissionEnabled = false;
            DarkMode = true;
        }
    }
}
