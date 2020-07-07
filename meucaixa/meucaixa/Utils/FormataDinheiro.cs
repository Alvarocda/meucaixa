namespace meucaixa.Utils
{
    public class FormataDinheiro
    {
        public string FormataValor(string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                string valorFormatado = "";
                var limpo = valor.Replace(".", "").Replace(",", "");
                if (limpo.Length > 2)
                {
                    limpo = string.Concat(limpo.Substring(0, limpo.Length - 2), ".", limpo.Substring(limpo.Length - 2));
                    var culture = new System.Globalization.CultureInfo("en-US");
                    valorFormatado = string.Format(culture, "{0:n}", double.Parse(limpo));
                }
                else
                {
                    int LimpoN;
                    var LRet = int.TryParse(limpo, out LimpoN);
                    if (LRet)
                    {
                        if (int.Parse(limpo) == 0)
                        {
                            valorFormatado = "";
                        }
                        else
                        {
                            limpo = string.Concat(new string('0', 3 - limpo.Length), limpo);
                            limpo = string.Concat(limpo.Substring(0, limpo.Length - 2), ".", limpo.Substring(limpo.Length - 2));
                            var culture = new System.Globalization.CultureInfo("en-US");
                            valorFormatado = string.Format(culture, "{0:n}", double.Parse(limpo));
                        }
                    }
                    else
                    {
                        valorFormatado = "";
                    }
                }
                return valorFormatado;
            }
            else
            {
                return valor;
            }
        }
    }
}
