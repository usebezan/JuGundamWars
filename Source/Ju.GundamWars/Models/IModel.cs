using System;


namespace Ju.GundamWars.Models
{

    public interface IModel
    {

        public void Insert();
        public void Update();
        public void Delete();
        public void Reload();
        public bool IsDirty();

    }

}
