using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINA_BATCH.FFManagement
{
    public struct StructInfo
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public int Pos { get; set; }
    }

    class StructureList
    {
        // Store the structures in this List object
        private List<Structure> lstObject = new List<Structure>();
        private int current = 0;

        public StructureList(){ }

        public StructureList(Structure[] structures)
        {
            for (int i = 0; i < structures.Length; i++)
                lstObject.Add(structures[i]);
        }

        public void add(Structure structure)
        {
            lstObject.Add(structure);
        }

        public void delete(int i)
        {
            lstObject.RemoveAt(i);
        }
        
        public int GetLength()
        {
            return lstObject.Count;
        }

        public StructInfo GetCurrentInfo()
        {
            Structure curStructure = lstObject[current];

            StructInfo curInfo = new StructInfo();
            curInfo.Name = curStructure.GetName();
            curInfo.Path = curStructure.GetPath();
            curInfo.Pos = current;

            return curInfo;
        }

        public int GetCurrentIndex()
        {
            return current;
        }

        public void SetCurrentIndex(int current)
        {
            this.current = current;
        }
    }
}
