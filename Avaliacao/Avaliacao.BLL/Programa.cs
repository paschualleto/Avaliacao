using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.BLL
{
    public class Programa
    {
        public static void validaCamposAddPrograma(string nome, string instrucao, int potencia, int tempo, string caracter)
        {

            if (string.IsNullOrEmpty(nome)) {
                throw new Exception("Informe o nome do alimento");
            }

            if (string.IsNullOrEmpty(instrucao)) {
                throw new Exception("Informe a instrução");
            }
            
            if (string.IsNullOrEmpty(caracter)) {
                throw new Exception("Informe um símbolo");
            }

            if (tempo > 120)
            {
                throw new System.Exception("O tempo máximo não pode ser superior à 120 segundos(2 minutos).");
            }

            if (tempo < 1)
            {
                throw new System.Exception("O tempo mínimo não pode ser menor que 1 segundo.");
            }

            if (potencia > 10)
            {
                throw new System.Exception("A potência máxima não pode ser superior à 10.");
            }

            if (potencia < 1)
            {
                throw new System.Exception("A potência mínima não pode ser menor à 1.");
            }
        }
    }
}
