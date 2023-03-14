using FirstAPI.Context;
using FirstAPI.Models;
using FirstAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstAPI.CRUD
{
    public class PlantsDAL
    {
        PlantDbContext db = new PlantDbContext();

        public IEnumerable<DetailsViewModel> GetAllDetails()
        {
            var detailsList = (from d in db.Details
                               join t in db.TreeNames on d.treeNameId equals t.Id
                               join ds in db.Diseases on d.diseaseId equals ds.Id
                               select new DetailsViewModel()
                               {
                                   Id = d.Id,
                                   imagePath = d.imagePath,
                                   Kind = d.Kind == false ? "Ağaç" : "Bitki",
                                   treeNameId = t.Name,
                                   diseaseId = ds.Name,
                                   Description = d.Description
                               }).ToList();
            return detailsList;
        }

        /// <summary>
        ///     Bu method veritabanında olan id eşitler ve onu döndürür
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DetailsByIdViewModel GetDetailsById(int id)
        {
            var DetailsByIdViewModel = db.Details.Where(d => d.Id == id).Select(d => new DetailsByIdViewModel()
            {
                Id = d.Id,
                imagePath = d.imagePath,
                Kind = d.Kind,
                treeNameId = d.treeNameId,
                diseaseId = d.diseaseId,
                Description = d.Description
            }).FirstOrDefault();

            return DetailsByIdViewModel;
        }

        /// <summary>
        ///     Bu method kayıt işlemini yürütüyor
        /// </summary>
        /// <param name="mgData"></param>
        /// <returns></returns>
        public CreateViewModel CreateDetails(CreateViewModel mgData)
        {
            Details details = new Details();
            details.imagePath = mgData.imagePath;
            details.Kind = mgData.Kind;
            details.treeNameId = mgData.treeNameId;
            details.diseaseId = mgData.diseaseId;
            details.Description = mgData.Description;
            db.Details.Add(details);
            db.SaveChanges();
            return mgData;
        }

        /// <summary>
        ///     Bu method güncelleme işlemini yürütüyor
        /// </summary>
        /// <param name="mgData"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public UpdateViewModel UpdateDetails(UpdateViewModel mgData, int id)
        {
            var update = db.Details.Find(id);
            update.imagePath = mgData.imagePath;
            update.Kind = mgData.Kind;
            update.treeNameId = mgData.treeNameId;
            update.diseaseId = mgData.diseaseId;
            update.Description = mgData.Description;
            db.Entry(update).State = System.Data.Entity.EntityState.Modified;
            //db.Details.Add(update);
            db.SaveChanges();
            return mgData;
        }

        /// <summary>
        ///  Bu method silme işlemini yürütüyor
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDetails(int id)
        {
            db.Details.Remove(db.Details.Find(id));
            db.SaveChanges();
        }
        public bool IsThereAnyDetails(int id)
        {
            return db.Details.Any(x => x.Id == id);
        }
    }
}