using APICompras.Models;
using System.Collections.Generic;

namespace APICompras.Services
{
    public interface ICompraService
    {
        IEnumerable<CompraItem> GetAllItems();
        CompraItem Add(CompraItem novoItem);
        CompraItem GetById(int id);
        void Remove(int id);
    }
}
