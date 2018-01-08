using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoREMobile.Models;

namespace CoREMobile.Interfaces
{
    /// <summary>
    /// Require that implementers have methods to set the order of top, middle, and bottom control sets
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IControlOrder<T>
    {
        T SetTopControlsOrder(T pageControls);
        T SetMiddleControlsOrder(T pageControls);
        T SetBottomControlsOrder(T pageControls);
    }
}
