using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelowanieKlas
{
    class User
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; set; }
        public string LastNAme { get; set; }
        public int Age { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime UpdatedAt { get; set; }
        public decimal Funds { get; private set; }

        public User(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email is incorrect");
            }
            if (Email == email)
            {
                return;
            }

            Email = email;
            Update();
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password is incorrect");
            }
            if (Password == password)
            {
                return;
            }

            Password = password;
            Update();
        }

        public void SetAge(int age)
        {
            if (age < 13)
            {
                throw new Exception("Ahe must be greater or equal to 13");
            }
            if (Age == age)
            {
                return;
            }

            Age = age;
            Update();
        }

        public void Activate()
        {
            if (IsActive)
            {
                return;
            }
            IsActive = true;
            Update();
        }

        public void Deactivate()
        {
            if (!IsActive)
            {
                return;
            }
            IsActive = false;
            Update();
        }

        public void  IncreaseFunds(decimal funds)
        {
            if (funds <= 0)
            {
                throw new Exception("Funds must be greater than 0.");
            }
            Funds += funds;
            Update();
        }

        public void PurchasedOrder(Order order)
        {
            if (!IsActive)
            {
                throw new Exception("Only actvie user can purchase an order.");
            }

            decimal orderPrice = order.TotalPrice;
            if (Funds - orderPrice < 0)
            {
                throw new Exception("You don't have enough money.");
            }

            order.Purchase();
            Funds -= orderPrice;
            Update();
        }

        private void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }



    }
}
