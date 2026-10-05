using API_CRUD_NET6.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace API_CRUD_NET6.Repositories
{
    public class ProdutoRepository
    {

        private static List<Produto> produtos = new();
        private static int contador = 1;

        public static List<Produto> ObterTodos() => produtos;

        public static Produto? ObterPorId(int id) =>
            produtos.FirstOrDefault(p => p.Id == id);

        public static Produto Criar(Produto produto)
        {
            produto.Id = contador++;
            produtos.Add(produto);
            return produto;
        }

        public static bool Atualizar(int id, Produto produtoAtualizado)
        {
            var index = produtos.FindIndex(p => p.Id == id);
            if (index == -1) return false;

            produtoAtualizado.Id = id;
            produtos[index] = produtoAtualizado;
            return true;
        }

        public static bool Remover(int id)
        {
            var produto = ObterPorId(id);
            if (produto == null) return false;

            produtos.Remove(produto);
            return true;
        }

    }
}
