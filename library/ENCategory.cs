using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCategory
    {
        private int _id;
        private string _name;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

        public ENCategory()
        {
            _id = 0;
            _name = "";
        }

        public ENCategory(int id, string name)
        {
            this._id = id;
            this._name = name;
        }

        public bool read()
        {
            CADCategory cad = new CADCategory();
            return cad.read(this);
        }

        public List<ENCategory> readAll()
        {
            CADCategory cad = new CADCategory();
            return cad.readAll();
        }

    }
}
