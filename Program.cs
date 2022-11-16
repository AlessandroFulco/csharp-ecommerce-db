/*
     * Prima parte
    Dato lo schema in allegato, producete tutte le classi e le relazioni necessarie per poter utilizzare EntityFramework (in modalità code-first) al fine di generare il relativo database.

    Seconda Parte
    Considerando che:
        1. ci sono clienti che effettuano ordini.
        2. Un ordine viene preparato da un dipendente.
        3. Un ordine ha associato uno o più pagamenti (considerando eventuali tentativi falliti)

    Realizzate le seguenti funzionalità:
        1. inserite 10 prodotti all’avvio del programma (i prodotti non devono essere inseriti in caso si riavvi l’applicazione)
        2. quando l’applicazione si avvia chiede se l’utente è un dipendete o un cliente
            a. se è un dipendente potrà eseguire CRUD sugli ordini
            b. se è un cliente potrà acquistare degli ordini
        3. simulate randomicamente l’esito di un acquisto (status = ok | status = ko)

    Bonus
        Il dipendente deve poter spedire gli ordini acquistati per cui il pagamento è andato a buon fine.
*/
using System.Collections.Generic;

Console.WriteLine("Ciao");

EcommerceDbContext db = new EcommerceDbContext();


Console.WriteLine("Benvenuto nell'ecommerce!");


bool esci = true;

do
{

    Console.Write("Inserisci se sei un dipendente o un cliente: ");
    string input = Console.ReadLine();


    switch (input)
    {
        case "dipendente":

            bool esciDipendente = true;
            do
            {
                // leggi ordine (read)
                List<Order> ordini = db.Orders.ToList();
                foreach(Order o in ordini)
                {
                    Console.WriteLine("{0} - {1} - {2}", o.Date, o.Amount, o.Status);
                }
                // modifica ordine (update)

                // cancella ordine (delete)

                // crea pagamento (create)
                Pagamento(db, ordini);




            } while (!esciDipendente);
            


            break;

        case "cliente":

            //            
            int i = 0;
            foreach (Product product in ProductList(db).ToList())
            {
                Console.WriteLine((i + 1) + " - " + product.Name);
                i++;
            }

            MenuCustomer();

            Console.Write("\nScegli un'opzione del menu: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            bool esciCliente = false;
            do
            {
                switch (choice)
                {


                    // crea ordine (create)
                    case 1:

                        //scegli il prodotto
                        Console.Write("Scegli il nome del prodotto che vuoi ordinare: ");
                        string nomeProdotto = Console.ReadLine();

                        //funzione crea ordine con parametro db 
                        CreaOrdine(db, nomeProdotto);


                        break;

                    case 2:
                        List<Product> products = ProductList(db);

                        i = 0;
                        foreach (Product product in products)
                        {
                            Console.WriteLine((i + 1) + " - " + product.Name);
                            i++;
                        }
                        break;

                    // modifica ordine (update)

                    // elimina ordine (delete)


                    case 3:
                        esciCliente = true;
                        break;

                    

                }
            } while (!esciCliente);

            break;

        case "esci":
            esci = false;
            break;

    }

} while (!esci);


void MenuCustomer()
{
    Console.WriteLine("Sezione: Lista Prodottis\n");
    Console.WriteLine("     1. Crea ordine");
    Console.WriteLine("     2. Lista Prodotti");
    Console.WriteLine("     3. Modifica ordine");
    Console.WriteLine("     4. Elimina ordine");
}

List<Product> ProductList(EcommerceDbContext db)
{
    List<Product> productList = db.Products.ToList<Product>();

    return productList;
}

void CreaOrdine(EcommerceDbContext db, string nomeProdotto)
{
    // trovare il prodotto
    Product product = db.Products.Where(p => p.Name == nomeProdotto).First();

    //dati utente
    Customer customer = db.Customers.First();

    //dati impiegato
    Employee employee = db.Employees.First();

    int random = new Random().Next(0, 2);
    bool stato = false;
    if (random == 1)
        stato = true;

    //creare ordine
    Order order = new Order() { Date = new DateTime(), Amount = product.Price, Status = stato, EmployeeId = employee.Id, CustomerId = customer.Id };
    db.Orders.Add(order);
    db.SaveChanges();
}

List<Order> OrderList(EcommerceDbContext db)
{
    List<Order> orders = db.Orders.ToList();

    return orders;
}

void Pagamento(EcommerceDbContext db, List<Order> ordini)
{
    int random = new Random().Next(1, 11);
    bool stato = false;
    if (random < 6)
        stato = true;
    Payment payment = new Payment() { OrderId = ordini.First().Id, Date = ordini.First().Date, Amount = ordini.First().Amount, Status = stato };
    db.Payments.Add(payment);
    db.SaveChanges();
}