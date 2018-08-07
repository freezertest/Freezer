using System.Collections.Generic;
using System.Linq;
using FreeezeDotNet.Repository;
using FreeezeDotNet.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace FreeezeDotNet.Model
{

    public class Food
    {
        private FreezerContext _db;
        private TypesListRepository _typesRepository;
        private List<FoodType> _types;
        private List<FoodPortion> _portions;
        private PortionsListRepository _portionsRepository;
        
        public int Id{get;set;}
        public string Name { get; set; }
        public FoodType Type { get; set; }
        public FoodPortion Portion { get; set; }
        public Drawer Drawer {get;set;}
        public int DrawerId {get;set;}
        public string Notes { get; set; }
        public int TypeId{get;set;}
        public int PortionId{get;set;}

        public Food()
        {
            _db = new FreezerContext();
            _typesRepository = new TypesListRepository();
            _types = _typesRepository.GetAllTypes();
            _portionsRepository = new PortionsListRepository();
            _portions = _portionsRepository.GetAllPortions();
        }

         public string VerifyFood(FormViewModel newFood)
        {
            if (_db.Freezers.Where(a => a.Id == newFood.Freezer).Count() <= 0)
                return "Errore nel Freezer. Controlla la tua scelta";
            else
            {
                var chosenFreezer = _db.Freezers.Include(p=>p.Drawers).FirstOrDefault(a => a.Id == newFood.Freezer);
                if (chosenFreezer.Drawers.Where(a => a.Id == newFood.Drawer).Count() <= 0)
                    return "Errore nel Cassetto. Controlla la tua scelta";
                else
                {
                    var type = _types.FirstOrDefault(a => a.Id == newFood.Type);
                    var portion = _portions.FirstOrDefault(a => a.Id == newFood.Portion);
                    if ((type.Name.ToUpper() == "PESCE" || type.Name.ToUpper() == "CARNE") && portion.Name.ToUpper() == "NONE" || type.Name.ToUpper().Contains("ERBE") && portion.Name.ToUpper() != "None")
                        return "Errore nel Tipo dell'alimento. Controlla la tua scelta";

                    var chosenDrawer = chosenFreezer.Drawers.FirstOrDefault(a => a.Id == newFood.Drawer);
                    _db.Foods.Add(new Food() { Name = newFood.Name, TypeId = type.Id, PortionId = portion.Id, Notes = newFood.Notes, DrawerId=chosenDrawer.Id});
                    _db.SaveChanges();
                    return "L'alimento è stato inserito con successo!";

                }

            }




        }

        public string Remove (int id)
        {
            if(_db.Foods.Where(a=>a.Id==id).Count()<=0)
            {
                return "Alimento inesistente";
            }

            _db.Foods.Remove(_db.Foods.FirstOrDefault(a=>a.Id==id));
            _db.SaveChanges();
            return "Alimento rimosso";


        }
    }

    

}