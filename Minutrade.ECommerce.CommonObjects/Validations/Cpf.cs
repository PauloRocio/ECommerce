namespace Minutrade.ECommerce.CommonObjects.Validations
{
    /// <summary>
    /// Classe de mecanismo de validação de CPF>
    /// </summary>
    public class Cpf
    {
        /// <summary>
        /// Método responsável por validar o CPF.
        /// </summary>
        /// <param name="cpfNumber">Número do CPF</param>
        /// <returns>verdadeiro caso ok. Caso contrário falso.</returns>
        public static bool Validade(string cpfNumber)
        {
            var multiplierOne = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplierTwo = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpfNumber = cpfNumber.Trim();
            cpfNumber = cpfNumber.Replace(".", "").Replace("-", "");

            if (cpfNumber.Length != 11)
                return false;

            var tempCpf = cpfNumber.Substring(0, 9);
            var sum     = 0;

            for (var i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplierOne[i];

            var rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            var digito = rest.ToString();
            tempCpf    = tempCpf + digito;
            sum        = 0;

            for (var i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplierTwo[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digito = digito + rest;

            return cpfNumber.EndsWith(digito);
        }
    }
}