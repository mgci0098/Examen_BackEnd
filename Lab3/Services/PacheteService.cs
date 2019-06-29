using CentruMultimedia.Models;
using Lab3.Models;
using Lab3.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Services
{
    public interface IPacheteService
    {
        IEnumerable<PachetGetModel> GetAll();
        IEnumerable<PachetGetModel> GetByExpeditor(string expeditor);
        PachetGetModel Create(PachetPostModel pachet);
        PachetGetModel Upsert(int id, PachetPostModel pachet);
        PachetGetModel Delete(int id);
    }


    public class PacheteService : IPacheteService
    {
        private FilmeDbContext context;
        public PacheteService(FilmeDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<PachetGetModel> GetAll()
        {
            return context.Pachete
                .Select(pachet => PachetGetModel.FromPachet(pachet))
                .OrderByDescending(p => p.Cost);
        }

        //public IEnumerable<PachetGetModel> GetAll()
        //{
        //    return context.Pachete.Select(pachet => PachetGetModel.FromPachet(pachet));
        //}

        public IEnumerable<PachetGetModel> GetByExpeditor(string expeditor)
        {
            IQueryable<Pachet> result = context.Pachete.Where(p => p.DenumireExpeditor == expeditor);

            return result.Select(p => PachetGetModel.FromPachet(p));
        }



        public PachetGetModel Create(PachetPostModel pachetModel)
        {
            Pachet toAdd = PachetPostModel.ToPachet(pachetModel);

            context.Pachete.Add(toAdd);
            context.SaveChanges();
            return PachetGetModel.FromPachet(toAdd);
        }
                     

        public PachetGetModel Upsert(int id, PachetPostModel pachetModel)
        {
            var existing = context.Pachete.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (existing == null)
            {

                Pachet toAdd = PachetPostModel.ToPachet(pachetModel);
                context.Pachete.Add(toAdd);
                context.SaveChanges();
                return PachetGetModel.FromPachet(toAdd);
            }

            //context.Entry(existing).State = EntityState.Detached;

            Pachet toUpdate = PachetPostModel.ToPachet(pachetModel);
            toUpdate.Id = id;
            context.Pachete.Update(toUpdate);
            context.SaveChanges();
            return PachetGetModel.FromPachet(toUpdate);
        }


        public PachetGetModel Delete(int id)
        {
            var existing = context.Pachete
                            .FirstOrDefault(p => p.Id == id);
            if (existing == null)
            {
                return null;
            }

            context.Pachete.Remove(existing);
            context.SaveChanges();

            return PachetGetModel.FromPachet(existing);
        }





    }
}
