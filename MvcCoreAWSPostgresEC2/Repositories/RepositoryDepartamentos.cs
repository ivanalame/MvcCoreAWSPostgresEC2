using Microsoft.EntityFrameworkCore;
using MvcCoreAWSPostgresEC2.Data;
using MvcCoreAWSPostgresEC2.Models;

namespace MvcCoreAWSPostgresEC2.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;

        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public  async Task<Departamento>FindDepartamentoAsync(int id)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(x => x.IdDepartamento == id);
        }

        public async Task InsertDeparatmentoAsync(int id, string nombre, string localidald)
        {
            Departamento dept = new Departamento
            {
                IdDepartamento = id,
                Nombre = nombre,
                Localidad = localidald
            };
            this.context.Departamentos.Add(dept);
            await this.context.SaveChangesAsync();
        }
    }
}
