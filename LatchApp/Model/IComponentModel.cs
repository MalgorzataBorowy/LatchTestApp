using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatchApp.Model
{
    public interface IComponentModel:IModel
    {
        int ComponentID { get; set; }
        string Type { get; set; }
        bool Status { get; set; }
    }
}
