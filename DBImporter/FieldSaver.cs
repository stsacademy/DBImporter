using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBImporter
{
    public class FieldSaver
    {
        private string FieldName;

        private bool FieldState;

        public FieldSaver(string fieldName, bool fieldState)
        {
            this.FieldName = fieldName;
            this.FieldState = fieldState;
        }

        public string GetName
        {
            get { return FieldName; }
        }

        public bool GetState
        {
            get { return FieldState; }
            set { FieldState = value; }
        }
    }

    public static class FieldSaverExtenssions
    {
        public static List<string> GetSelectedFields(this IEnumerable<FieldSaver> collection)
        {
            List<string> list = new List<string>();
            foreach (var field in collection)
            {
                if (field.GetState)
                    list.Add(field.GetName);
            }

            return list;
        }
    }
}
