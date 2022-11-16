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


public class Payment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public bool Status { get; set; }


    //foreign key
    public int OrderId { get; set; }
    public Order Order { get; set; }

}
