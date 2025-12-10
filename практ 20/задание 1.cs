using System;

namespace ATM
{
    public class NotEnoughMoneyException : Exception
    {
        public decimal Balance { get; }
        public decimal RequiredAmount { get; }

        public NotEnoughMoneyException(decimal balance, decimal requiredAmount)
            : base($"Недостаточно средств! Баланс: {balance}, нужно: {requiredAmount}")
        {
            Balance = balance;
            RequiredAmount = requiredAmount;
        }
    }

    public class WrongPinException : Exception
    {
        public int AttemptsLeft { get; }

        public WrongPinException(int attemptsLeft)
            : base($"Неверный PIN! Осталось попыток: {attemptsLeft}")
        {
            AttemptsLeft = attemptsLeft;
        }
    }

    public class ATM
    {
        private decimal _balance;
        private const int CorrectPin = 1234;
        private int _pinAttemptsLeft;
        private bool _isBlocked;

        public ATM(decimal initialBalance)
        {
            _balance = initialBalance;
            _pinAttemptsLeft = 3;
            _isBlocked = false;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > _balance)
            {
                throw new NotEnoughMoneyException(_balance, amount);
            }

            _balance -= amount;
            Console.WriteLine($"Успешно снято: {amount}. Новый баланс: {_balance}");
        }

        public void EnterPin(int pin)
        {
            if (_isBlocked)
            {
                throw new InvalidOperationException("Карта заблокирована!");
            }

            if (pin == CorrectPin)
            {
                _pinAttemptsLeft = 3; 
                Console.WriteLine("PIN верный!");
                return;
            }

            _pinAttemptsLeft--;

            if (_pinAttemptsLeft == 0)
            {
                _isBlocked = true;
                throw new InvalidOperationException("Карта заблокирована!");
            }

            throw new WrongPinException(_pinAttemptsLeft);
        }

        public decimal GetBalance()
        {
            return _balance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM(500);

            Console.WriteLine($"Баланс: {atm.GetBalance()}");

            Console.WriteLine("Снимаем 1000...");
            try
            {
                atm.Withdraw(1000);
            }
            catch (NotEnoughMoneyException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine();

            int[] pins = { 0000, 1111, 9999 };
            foreach (int pin in pins)
            {
                Console.WriteLine($"Ввод PIN: {pin:D4}");
                try
                {
                    atm.EnterPin(pin);
                }
                catch (WrongPinException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    break;
                }
            }
        }
    }
}
