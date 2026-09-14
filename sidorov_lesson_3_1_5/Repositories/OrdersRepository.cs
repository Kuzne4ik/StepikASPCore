using lesson_3_1_5.Models;
using lesson_3_1_5.Repositories;

namespace lesson_3_1_5.Repositories
{
    public class OrdersRepository: IOrdersRepository
    {
        public static List<Order> _orders = new List<Order>();


        public OrdersRepository()
        {
        }

        public List<Order>? GetAll()
        {
            return _orders;
        }

        public Order AddOrder(Guid userId, Cart cart)
        {
            // Если корзина для данного пользователя не найдена, создаем новую

            var order = new Order(Guid.NewGuid(), Constants.UserId); // Используем StartGuid для первой корзины

            foreach (var cartItem in cart.Items)
            {
                order.Items.Add(new OrderItem(new Guid(), cartItem.Product, cartItem.Quantity));
            }

            _orders?.Add(order);

            return order;
        }

        public Order? TryGetById(Guid id)
        {
            return _orders?.FirstOrDefault(t => t.Id == id);
        }

        public void Update(Order order)
        {
            var targetOrder = _orders.FirstOrDefault(t => t.Id == order.Id);
            if (targetOrder != null)
            {
                targetOrder.Phone = order.Phone;
                targetOrder.Address = order.Address;
                targetOrder.UserName = order.UserName;

                targetOrder.Items = targetOrder.Items;
                return;
            }
            throw new Exception($"Order not found by id: {order.Id}");
        }
    }

    public interface IOrdersRepository
    {
        List<Order>? GetAll();

        Order AddOrder(Guid userId, Cart cart);

        Order? TryGetById(Guid id);

        void Update(Order order);
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        