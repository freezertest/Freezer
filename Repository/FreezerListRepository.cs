using System.Collections.Generic;
using FreeezeDotNet.Model;
using System.Linq;

namespace FreeezeDotNet.Repository{

public class FreezerListRepository{

 private List<Freezer> _freezerList;

    public FreezerListRepository(){
            _freezerList=new List<Freezer>();
            _freezerList.Add(new Freezer("Freezer Cucina UP", "Cucina UP", 1));
            _freezerList.Add(new Freezer("Freezer Cucina PT", "Cucina PT", 2));
            _freezerList.Add(new Freezer("Freezer Cantina","Cantina", 3));  
    }

    public List<Freezer> GetAll(){
        return _freezerList;
    }

    public Freezer GetById(int id){
        return _freezerList.FirstOrDefault(a=> a.Id==id);
    }
}
}