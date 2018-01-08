using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoREMobile.Interfaces
{
    /// <summary>
    /// Require that implementers have creation methods for the top, middle, and bottom control sets
    /// </summary>
    public interface IPropertyPageControls
    {
        void BuildTopControls();
        void BuildMiddleControls();
        void BuildBottomControls();

    }
}
