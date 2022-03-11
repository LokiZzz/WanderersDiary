using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models;

namespace WanderersDiary.CharacterManagement.Extensions
{
    public static class InventoryExtensions
    {
        public static Equipment X(this Equipment item, int quantity)
        {
            item.Quantity = quantity;

            return item;
        }

        public static Equipment With(this Equipment item, params Equipment[] content)
        {
            if(item.Content == null) item.Content = new List<Equipment>();

            foreach(Equipment contentItem in content) item.Content.Add(contentItem);

            return item;
        }

        public static List<Equipment> ToList(this Equipment item)
        {
            return new List<Equipment> { item };
        }
    }
}
