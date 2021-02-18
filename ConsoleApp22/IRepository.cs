namespace ConsoleApp22
{
    public interface IRepository
    {
        public string ConnectionString { get; set; }   
        void EscreverTeste(string mensagem);
    }
}