using lesson_2_1_2.Models;

namespace lesson2_1.Repositories
{
    public class CartsRepository
    {
        readonly List<Cart>? _carts;

        internal CartsRepository()
        {

            _carts = new List<Cart>
            {
            };
        }

        public List<Cart>? GetAll()
        {
            return _carts;
        }

        public Cart? TryGetById(int id)
        {
            return _carts?.FirstOrDefault(t => t.Id == id);
        }

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        