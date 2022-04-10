using System;
using System.Threading.Tasks;
using ProaAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces.Repositories;
using ProAtividade.Domain.Interfaces.Services;

namespace ProAtividade.Domain.Services
{
    public class AtividadeService : IAtividadeService
    {
        private readonly IAtividadeRepo _atividadesRepo;
        public AtividadeService(IAtividadeRepo atividadesRepo)
        {
            _atividadesRepo = atividadesRepo;
        }
        public async Task<Atividade> AdicionarAtividade(Atividade model)
        {
            if (await _atividadesRepo.PegaPorTituloAsync(model.Titulo) != null)
                throw new Exception("Já existe uma atividade com esse título");

            if (await _atividadesRepo.PegaPorIdAsync(model.Id) == null)
            {
                _atividadesRepo.Adicionar(model);
                if (await _atividadesRepo.SalvarMudancasAsync())
                    return model;
            }

            return null;
        }

        public async Task<Atividade> AtualizarAtividade(Atividade model)
        {
            if (model.DataConclusao != null)
                throw new Exception("Não se pode alterar atividade já concluida.");
            if (await _atividadesRepo.PegaPorIdAsync(model.Id) != null)
            {
                _atividadesRepo.Atualizar(model);
                if (await _atividadesRepo.SalvarMudancasAsync())
                    return model;
            }

            return null;
        }

        public async Task<bool> ConcluirAtividade(Atividade model)
        {
            if (model != null)
            {
                model.Concluir();
                _atividadesRepo.Atualizar<Atividade>(model);
                return await _atividadesRepo.SalvarMudancasAsync();
            }

            return false;
        }

        public async Task<bool> DeletarAtividade(int atividadeId)
        {
            var atividade = await _atividadesRepo.PegaPorIdAsync(atividadeId);
            if (atividade == null) throw new Exception("Atividade que tentou deletar não existe");

            _atividadesRepo.Deletar(atividade);
            return await _atividadesRepo.SalvarMudancasAsync();
        }

        public async Task<Atividade> PegarAtividadePorIdAsync(int atividadeId)
        {
            try
            {
                var atividade = await _atividadesRepo.PegaPorIdAsync(atividadeId);
                if (atividade == null) return null;

                return atividade;
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Atividade[]> PegarTodasAtividadesAsync()
        {
            try
            {
                var atividades = await _atividadesRepo.PegaTodasAsync();
                if (atividades == null) return null;

                return atividades;
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}