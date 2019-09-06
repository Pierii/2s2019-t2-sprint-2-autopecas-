using Microsoft.EntityFrameworkCore;
using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecaRepository
    {

        public List<Pecas> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                // SELECT * FROM Pecas
                return ctx.Pecas.Include(x => x.Fornecedor).ToList();
            }
        }

        public void Cadastrar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                // INSERT INTO
                ctx.Pecas.Add(peca);
                ctx.SaveChanges();
            }
        }

        public Pecas BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                // select com where
                // id da nossa tabela seja igual ao id enviado pelo usuario
                return ctx.Pecas.FirstOrDefault(x => x.PecaId == id);
            }
        }

        public void Atualizar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas PecaBuscada = ctx.Pecas.FirstOrDefault(x => x.PecaId == peca.PecaId);
                PecaBuscada.Codigo = peca.Codigo;
                PecaBuscada.Descricao = peca.Descricao;
                PecaBuscada.Peso = peca.Peso;
                PecaBuscada.PrecoCusto = peca.PrecoCusto;
                PecaBuscada.PrecoVenda = peca.PrecoVenda;
                ctx.Pecas.Update(PecaBuscada);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                // DELETE FROM Pecas WHERE IdCategoria = @Id;
                // encontrar quem eu quero deletar
                Pecas JogoBuscado = ctx.Pecas.Find(id);
                // remover o fofinho do contexto
                ctx.Pecas.Remove(JogoBuscado);
                // efetivar no banco essa mudança
                ctx.SaveChanges();
            }
        }
    }
}
