namespace Inventory.ViewModel
{

    public class TypeViewModel
    {

        public string FreezerName { get; set; }
        public string DrawerName { get; set; }
        public string Portion { get; set; }
        public string Notes { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public TypeViewModel(string freezerName = "", string drawerName = "", string portion = "", string notes = "", string name = "")
        {
            FreezerName = freezerName;
            DrawerName = drawerName;
            Portion = portion;
            Notes = notes;
            Name = name;
        }


    }
}