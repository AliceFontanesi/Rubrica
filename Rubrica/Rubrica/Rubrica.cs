using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica
{
    class Rubrica : IDictionary
    {
        Dictionary<IComparable, object> dizionario = new Dictionary<IComparable, object>();
        public override string ToString()
        {
            string rubrica = "";
            foreach (var item in dizionario)
                rubrica += item.Value.ToString() + "\n";
            return rubrica;
        }

        public bool isEmpty()
        {
            if (dizionario.Count == 0)
                return true;
            return false;
        }

        public void makeEmpty()
        {
            dizionario.Clear();
        }

        public void insert(IComparable key, object value)
        {
            Pair coppia = new Pair((string)key, long.Parse(value.ToString()));
            bool trovato = false;
            if(dizionario.Count == 0)
                dizionario.Add(key, coppia);
            foreach (var item in dizionario)
            {
                if (item.Key == key)
                    trovato = true;
            }
            if (trovato)
                dizionario[key] = coppia;
            else
                dizionario.Add(key, coppia);
        }

        public void remove(IComparable key)
        {
            try
            {
                dizionario.Remove(key);
            }
            catch (Exception)
            {
                throw new Exception("Elemento non presente");
            }
        }

        public object find(IComparable key)
        {
            if (dizionario.ContainsKey(key))
                return dizionario[key];
            return new Exception("Elemento non presente");
        }

        //classe privata Pair: non modificare!!
        private class Pair
        {
            string name;
            long phone;

            public Pair(string aName, long aPhone)
            {
                name = aName;
                phone = aPhone;
            }

            public string getName()
            { return name; }

            public long getPhone()
            { return phone; }

            public override string ToString()
            {
                return name + " : " + phone;
            }
        }
    }


    interface IDictionary
    {
        /*
            verifica se il dizionario contiene almeno una coppia chiave/valore
        */
        bool isEmpty(); //fatto

        /*
            svuota il dizionario
        */
        void makeEmpty();//fatto

        /*
         Inserisce un elemento nel dizionario. L'inserimento va sempre a buon fine.
         Se la chiave non esiste la coppia key/value viene aggiunta al dizionario; 
         se la chiave esiste gia' il valore ad essa associato viene sovrascritto 
         con il nuovo valore; se key e` null viene lanciata IllegalArgumentException
        */
        void insert(IComparable key, object value);

        /*
         Rimuove dal dizionario l'elemento specificato dalla chiave key
         Se la chiave non esiste viene lanciata DictionaryItemNotFoundException 
        */
        void remove(IComparable key);

        /*
         Cerca nel dizionario l'elemento specificato dalla chiave key
         La ricerca per chiave restituisce soltanto il valore ad essa associato
         Se la chiave non esiste viene lanciata DictionaryItemNotFoundException
        */
        object find(IComparable key);
    }
}

