using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex_16_TsN
{
    class Client
    {
        private string name;
        private string lastName;
        private int age;
        private string numb;
        public List<BankAccount> BA;
        int sum;
        int sumSub;
        int sumT;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Number
        {
            get { return numb; }
            set { numb = value; }
        }

        public Client(string name, string lastName, int age, string numb, List<BankAccount> BA)
        {
            this.name = name;
            this.lastName = lastName;
            this.age = age;
            this.numb = numb;
            this.BA = BA;
        }

        public void print()
        {
            Console.WriteLine("<------------------------------------------->");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Last name: " + lastName);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Number of client: " + numb);
            for (int i = 0; i < BA.Count; i++)
            {
                BA[i].print();
            }
        }

        public void sumA()
        {
            for (int i = 0; i < BA.Count; i++)
            {
                sum += BA[i].SumOnAcc;
            }
            Console.WriteLine("Sum on all account: " + sum);
        }
        public void sumSub_T()
        {
            for (int i = 0; i < BA.Count; i++)
            {
                if (BA[i].SumOnAcc > 0)
                    sumT += BA[i].SumOnAcc;
                else if (BA[i].SumOnAcc < 0)
                    sumSub += BA[i].SumOnAcc;
            }
            Console.WriteLine("Possitive: "+sumT);
            Console.WriteLine("Negative: " + sumSub);
        }

        public void sortAccByNameAsc()
        {
            //BA.Sort();
            var sortedAccounts = from a in BA
                                 orderby a.NameOfAcc ascending
                                 select a;
            foreach (BankAccount b in sortedAccounts)
            {
                b.print();
            }
        }
        public void sortAccByNameDes()
        {
            var sortedAccounts = from a in BA
                                 orderby a.NameOfAcc descending
                                 select a;
            foreach (BankAccount b in sortedAccounts)
                b.print();
        }
        public void sortAccByNumbAsc()
        {
            var sortedAcc = from a in BA
                            orderby a.NumbOfAcc ascending
                            select a;
            foreach (BankAccount b in sortedAcc)
                b.print();
        }
        public void sortAccByNumbDes()
        {
            var sortedAcc = from a in BA
                            orderby a.NumbOfAcc descending
                            select a;
            foreach (BankAccount b in sortedAcc)
                b.print();
        }

        public int search(string str)
        {
            for (int i = 0; i < BA.Count; i++)
            {
                if (BA[i].NameOfAcc == str)
                {
                    BA[i].print();
                    return i;
                }            
            }
            return 0;
        }
    }

    class BankAccount
    {
        string nameOfAcc;
        int numbOfAcc;
        int sumOnAcc;
        bool ban;

        public string NameOfAcc
        {
            get { return nameOfAcc; }
            set { nameOfAcc = value; }
        }
        public int NumbOfAcc
        {
            get { return numbOfAcc; }
            set { numbOfAcc = value; }
        }
        public int SumOnAcc
        {
            get { return sumOnAcc; }
            set { sumOnAcc = value; }
        }

        public BankAccount(string nameOfAcc, int numbOfAcc, int sumOnAcc)
        {
            this.nameOfAcc = nameOfAcc;
            this.numbOfAcc = numbOfAcc;
            this.sumOnAcc = sumOnAcc;
        }

        public void print()
        {
            Console.WriteLine("Name of account: " + nameOfAcc);
            Console.WriteLine("Number of account: " + numbOfAcc);
            Console.WriteLine("Sum of money on account($): " + sumOnAcc);
        }

        public void sumPlus(int sum)
        {
            if ((ban == true) && (sum + sumOnAcc >= 0))
            {
                sumOnAcc += sum;
                Console.WriteLine("Ban is destroy");
                ban = false;
            }
            else if ((ban == true) && (sum + sumOnAcc < 0))
            {
                sumOnAcc += sum;
                Console.WriteLine("Your sum on account is {0}, you need to put more money to unlock account",sum+sumOnAcc);
            }
        }
        public void sumMinus(int sum)
        {
            if ((sumOnAcc > 0) && (ban == false))
            {
                sumOnAcc -= sum;
                if (sumOnAcc < -500)
                {
                    Console.WriteLine("There is no money on the account, you just got a ban");
                    ban = true;
                }
            }
            else if ((sumOnAcc < 0) && (ban == false))
            {
                if ((sumOnAcc < 0) && (sumOnAcc > -500))
                    Console.WriteLine("You cant take off money from account because in your account no money. \nIf you dont got money on account, your account got ban ");
                else if (sumOnAcc >= -500)
                    Console.WriteLine("You account got ban");
            }
            
        }


    }

    class ClientBase : IEnumerable
    {
        List<Client> Clients;
        public ClientBase(List<Client> Clients)
        {
            this.Clients = Clients;
        }

        public int Lenght
        {
            get { return Clients.Count; }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Clients.Count; i++)
            {
                yield return Clients[i];
            }
        }

        public IEnumerable Backwards()
        {
            for (int i = Clients.Count - 1; i >= 0; i--)
            {
                yield return Clients[i];
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter quantity");
            int n = int.Parse(Console.ReadLine());
            List<Client> cl = new List<Client>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("<------------------------------------------->");
                Console.WriteLine("Enter name ");
                string str1 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter last name ");
                string str2 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter age ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter number ");
                string numb = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter quantity of accounts");
                int m = int.Parse(Console.ReadLine());
                List<BankAccount> BA = new List<BankAccount>();
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Enter name of account ");
                    string str = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter numb of account ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter sum on account ");
                    int sumOn = Convert.ToInt32(Console.ReadLine());
                    BA.Add(new BankAccount(str,num,sumOn));
                }
                cl.Add(new Client(str1,str2,age,numb,BA));
            }
            foreach (Client c in cl)
                c.print();
            Console.WriteLine("<------------------------------------------->");
            Console.WriteLine("Sort by name -> ...");
            cl[0].sortAccByNameDes();
            Console.WriteLine("<------------------------------------------->");
            string str3 = Convert.ToString(Console.ReadLine());          
            int id = cl[0].search(str3);
            cl[0].BA[id].sumMinus(300);
            ClientBase CB = new ClientBase(cl);
            foreach (Client c in CB.Backwards())
                c.print();
            Console.ReadKey();
        }
    }
}
