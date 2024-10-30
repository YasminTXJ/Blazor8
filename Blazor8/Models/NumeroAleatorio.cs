namespace Blazor8.Models
{
    public class NumeroAleatorio
    {
        public int NumeroIdentificador { get; set; }

        public NumeroAleatorio() { 
            Random rdn = new Random();
            NumeroIdentificador = rdn.Next(0, 1000);
        }
    }
}
