using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMenu.domain
{
    public class OrderManager
    {
        public static void CreateOrder(DTO.OrderDTO orderDTO)
        {
            //Validation
            if(orderDTO.Name.Trim().Length == 0)
            {
                throw new Exception("Name is required.");
            }
            if (orderDTO.Address.Trim().Length == 0)
            {
                throw new Exception("Address is required.");
            }
            if (orderDTO.Zip.Trim().Length == 0)
            {
                throw new Exception("Zip code is required.");
            }
            if (orderDTO.Phone.Trim().Length == 0)
            {
                throw new Exception("Phone number is required.");
            }

            orderDTO.OrderID = Guid.NewGuid();
            orderDTO.TotalCost = PizzaPriceManager.CalculateCost(orderDTO);
            Data.OrderRepository.CreateOrder(orderDTO);
        }

        public static void completeOrder(Guid orderId)
        {
            Data.OrderRepository.CompleteOrder(orderId);
        }

        public static object GetOrders()
        {
            return Data.OrderRepository.GetOrders();
        }
    }
}
