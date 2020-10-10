using Microsoft.EntityFrameworkCore;
using PSI.TI.GestaoEscolar.Domain.Interfaces.Repository;
using PSI.TI.GestaoEscolar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSI.TI.GestaoEscolar.Data.Repository
{
    public class ResponsavelRepository : IResponsavelRepository
    {
        private readonly Context _context;
        public IUnitOfWork UnitOfWork => _context;

        public ResponsavelRepository(Context context)
        {
            _context = context;
        }

        public async Task<Responsavel> ObterPorId(Guid id)
        {
            return await _context.Responsaveis.Include(r => r.Dependentes).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Responsavel>> ObterTodos()
        {
            return await _context.Responsaveis.AsNoTracking().Include(r => r.Dependentes).ToListAsync();
        }

        public void Adicionar(Responsavel responsavel)
        {
            _context.Responsaveis.Add(responsavel);
        }

        public void Atualizar(Responsavel responsavel)
        {
            _context.Responsaveis.Update(responsavel);
        }

        public void Remover(Guid id)
        {
            _context.Responsaveis.Remove(ObterPorId(id).Result);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}