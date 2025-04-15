namespace apiClientes.Helpers.Functions
{
    public class ValidarDocumento
    {
        public static string MascaraDocumento(string documento)
        {
            var resultado = string.Empty;

            if (documento.Length == 14)
            {
                resultado = documento.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
            }

            else if (documento.Length == 11)
            {
                resultado = documento.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            }

            return resultado;
        }
    }
}
