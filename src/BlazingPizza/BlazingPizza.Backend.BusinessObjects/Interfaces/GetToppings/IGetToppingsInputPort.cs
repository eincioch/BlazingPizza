using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPizza.Backend.BusinessObjects.Interfaces.GetToppings;
public interface IGetToppingsInputPort
{
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();
}
