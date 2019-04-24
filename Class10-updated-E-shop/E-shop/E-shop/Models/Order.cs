using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_shop.Models
{
    public class Order
    {
        private List<OrderLine> _orderLines = new List<OrderLine>();

        public void AddOrderLine(Product product, int quantity, int index)
        {
            OrderLine line = new OrderLine();
            line.Index = index;
            line.ProductName = product.Name;
            line.Quantity = quantity;
            line.Price = product.Price;
            _orderLines.Add(line);
        }
        public int GetCount()
        {
            return _orderLines.Count;
        }
        public double OrderTotal()
        {
            double total = 0;
            foreach (var orderLine in _orderLines)
            {
                total += orderLine.OrderLineTotal();
            }
            return total;
        }

        public void PrintOrderList()
        {
            Console.WriteLine($" Index  | Product Name |  Quantity  |  Price  |" +
                    $"  Total for item");
            Console.WriteLine("--------------------------------------------------------------------------");
            foreach (var orderLine in _orderLines)
            {
                Console.WriteLine($" {orderLine.Index}    |  {orderLine.ProductName}  |   {orderLine.Quantity}  |  {orderLine.Price}  |" +
                    $"  Total for item: {orderLine.OrderLineTotal()}");
            }
        }
        public string PrintForReceipt()
        {
            string allProducts = $"\n\t Index  | Product Name |  Quantity  |  Price  |     Total for item";
            foreach (var orderLine in _orderLines)
            {
                allProducts += $"\n\t {orderLine.Index}    |  {orderLine.ProductName}  |   {orderLine.Quantity}  |  {orderLine.Price}  |" +
                    $"  Total for item: {orderLine.OrderLineTotal()}";
            }
            return allProducts;
        }
        public void RemoveItemFromOrder(int i)
        {
            for (int i1 = 0; i1 < _orderLines.Count; i1++)
            {
                OrderLine orderLine = _orderLines[i1];
                if (i == orderLine.Index)
                {
                    _orderLines.Remove(orderLine);
                }
            }
        }
        //private class for each line
        private class OrderLine
        {
            public string ProductName { get; set; }
            public int Index { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
            public double OrderLineTotal()
            {
                return Price * Quantity;
            }
        }

        public void Print2d()
        {
            IList<List<string>> list2D = _orderLines
                .Select(x => new List<string> { x.Index.ToString(), x.ProductName, x.Quantity.ToString(), x.Price.ToString(), OrderTotal().ToString() })
                .ToList();
            int h = list2D.Count;
            int w = list2D.Max(l => l.Count);
            for (int j = 0; j < w; j++)
            {
                for (int i = 0; i < h; i++)
                {
                    if (j < list2D[i].Count)
                        Console.Write(list2D[i][j]);
                    else
                        Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}
