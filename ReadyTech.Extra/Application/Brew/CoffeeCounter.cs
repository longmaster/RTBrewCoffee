
using Application.Interfaces;

namespace Application.Brew
{
    public class CoffeeCounter : ICoffeeCounter
    {
        private int _counter;
        public int Counter { get => _counter; }

        public CoffeeCounter() {
            
            _counter = 1;
        }

        public void Execute() { 
            _counter++;
        }
    }
}
