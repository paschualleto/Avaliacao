using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.BLL
{
   public class Avaliacao
    {
        public static void validaCamposAquecerNormal(int valorTempo, int valorPotencia)
        {
            if (valorTempo > 120) {
                throw new System.Exception("O tempo máximo não pode ser superior à 120 segundos(2 minutos).");
            }

            if (valorTempo < 1) {
                throw new System.Exception("O tempo mínimo não pode ser menor que 1 segundo.");
            }

            if (valorPotencia > 10) {
                throw new System.Exception("A potência máxima não pode ser superior à 10.");
            }

            if (valorPotencia < 1) {
                throw new System.Exception("A potência mínima não pode ser menor à 1.");
            }
        }
    }
}
