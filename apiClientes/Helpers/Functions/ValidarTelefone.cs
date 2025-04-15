namespace apiClientes.Helpers.Functions
{
    public class ValidarTelefone
    {
        public static string MascaraTelefone(string telefone)
        {
            

            if (telefone.Length == 10)
            {
                return string.Format("({0}) {1}-{2}", telefone.Substring(0, 2),
                    telefone.Substring(2, 4), telefone.Substring(6, 4));
            }
            else if (telefone.Length == 11)
            {
                return string.Format("({0}) {1}-{2}", telefone.Substring(0, 2),
                    telefone.Substring(2, 5), telefone.Substring(6, 4));
            }
            else
            {
                throw new FormatException("O telefone deve ter 10 ou 11 digitos");
            }
        }
    }
}
