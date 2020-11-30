using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatchApp.Model
{
    public interface ILatchModel:IModel
    {
        int LatchID { get; set; }
        string Type { get; set; }
        int ComponentID { get; set; }
    }
}
