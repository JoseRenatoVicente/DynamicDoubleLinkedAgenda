using System;

namespace DynamicAgendaList.Entities
{
    internal class Agenda
    {
        public Contact Head { get; set; }
        public Contact Tail { get; set; }

        public void PrintPaused()
        {
            if (IsEmpty()) Console.WriteLine("The list is empty.");
            else
            {
                Console.WriteLine("========== The elements of the List are =========\n");
                Contact aux = Head;
                do
                {
                    Console.WriteLine(aux.ToString());
                    aux = aux.Next;

                    if (aux != null)
                    {
                        Console.WriteLine("Press any key to show the next contact\n");
                        Console.ReadKey();
                    }

                } while (aux != null);

                Console.WriteLine("========== End of print =========\n");
            }
        }

        public int Count()
        {
            if (IsEmpty()) return 0;
            else
            {
                Contact aux = Head;
                int count = 0;
                do
                {
                    count++;
                    aux = aux.Next;

                } while (aux != null);
                return count;
            }

        }

        /*public Contact Search(string name)
        {
            if (IsEmpty()) Console.WriteLine("The list is empty.");
            else
            {
                Contact aux = Head;
                do
                {
                    if (name.ToLower() == aux.Name)
                    {
                        Console.WriteLine(aux.ToString() + "\n");
                        return aux;
                    }
                    aux = aux.Next;
                } while (aux != null);
            }
            return null;
        }*/

        public Contact[] Search(string where)
        {
            Contact[] searchContact = new Contact[Count()];
            int countSearch = 0;

            if (IsEmpty()) Console.WriteLine("The list is empty.");
            else
            {
                Contact aux = Head;
                do
                {
                    if (aux.Name.ToLower().Contains(where) || aux.Id.ToString().Contains(where))
                    {
                        searchContact[countSearch++] = aux;
                    }
                    aux = aux.Next;
                } while (aux != null);
            }
            return searchContact;
        }

        public Contact Push(Contact aux)
        {
            if (IsEmpty())
            {
                aux.Id = 1;
                Head = Tail = aux;
            }
            else
            {
                aux.Id = GetId();

                //Tail
                if (aux.Name.CompareTo(Tail.Name) >= 0)
                {
                    aux.Previous = Tail;
                    Tail.Next = aux;
                    Tail = aux;
                }
                //Head
                else if (aux.Name.CompareTo(Head.Name) < 0)
                {
                    aux.Next = Head;
                    Head.Previous = aux;
                    Head = aux;
                }
                //Mid
                else
                {
                    Contact aux1 = Head;
                    do
                    {

                        if (aux.Name.CompareTo(aux1.Next.Name) < 0)
                        {
                            aux.Previous = aux1;
                            aux1.Next.Previous = aux;

                            aux.Next = aux1.Next;
                            aux1.Next = aux;
                            break;
                        }
                        aux1 = aux1.Next;

                    } while (aux1.Next != null);
                }
            }

            return aux;
        }

        public int GetId()
        {
            Contact aux1 = Head;
            int idCount = Head.Id + 1;

            while (aux1.Next != null)
            {

                if (idCount <= aux1.Next.Id)
                {
                    idCount = aux1.Next.Id + 1;
                }
                aux1 = aux1.Next;
            }

            return idCount;
        }


        public void Pop(int id)
        {
            if (IsEmpty()) Console.WriteLine("The list is empty.");
            else if (id == Head.Id)
            {
                if (Head.Next == null)
                    Tail = Head = null;
                else
                {
                    Head = Head.Next;
                    Head.Previous = null;
                }
            }
            else
            {
                Contact aux1 = Head;
                do
                {
                    if (aux1.Next.Id == id)
                        if (aux1.Next.Next == null)
                        {
                            Tail = aux1;
                            aux1.Next = null;
                        }
                        else
                        {
                            aux1.Previous = aux1.Previous;

                            aux1.Next = aux1.Next.Next;

                            aux1.Next.Previous = aux1;
                            break;
                        }

                    aux1 = aux1.Next;

                } while (aux1 != null);

            }
        }


        public bool IsEmpty()
        {
            return (Head == null) && (Tail == null) ? true : false;
        }
    }
}
