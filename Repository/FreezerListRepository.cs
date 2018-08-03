using System.Collections.Generic;
using FreeezeDotNet.Model;
using System.Linq;
using FreeezeDotNet.ViewModel;

namespace FreeezeDotNet.Repository
{

    public class FreezerListRepository
    {

        private List<Freezer> _freezerList;

        public FreezerListRepository()
        {
            _freezerList = new List<Freezer>();
            _freezerList.Add(new Freezer("Freezer Cucina UP", "Cucina UP", 1));
            _freezerList.Add(new Freezer("Freezer Cucina PT", "Cucina PT", 2));
            _freezerList.Add(new Freezer("Freezer Cantina", "Cantina", 3));
        }

        public List<Freezer> GetAll()
        {
            return _freezerList;
        }

        public Freezer GetById(int id)
        {
            return _freezerList.FirstOrDefault(a => a.Id == id);
        }

        public string VerifyFood(FormViewModel newFood)
        {
            if(_freezerList.Where(a=> a.Id==newFood.Freezer).Count()>0){
                var chosenFreezer=_freezerList.FirstOrDefault(a=> a.Id==newFood.Freezer);
                if(chosenFreezer.drawers.Where(a=> a.Id==newFood.Drawer).Count()>0){
                    var chosenDrawer=chosenFreezer.drawers.FirstOrDefault(a=> a.Id==newFood.Drawer);
                    if((newFood.Type==FoodTypeEnum.Pesce||newFood.Type==FoodTypeEnum.Carne||newFood.Type==FoodTypeEnum.Legumi||newFood.Type==FoodTypeEnum.Verdura)&&newFood.Portion==FoodPortionEnum.None){
                        return "error";
                    }
                    else
                    {
                        chosenDrawer.DrawerFood.Add(new Food(){Name=newFood.Name, Type=newFood.Type, Portion=newFood.Portion, Notes=newFood.Notes});
                        return "insert";
                    }
                }
                else
                return "drawererror";
            }
            else
            return "freezererror";
                
            }
        }
    }