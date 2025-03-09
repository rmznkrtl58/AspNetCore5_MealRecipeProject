using BusinessLogicLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class SuggestRecipeManager : ISuggestRecipeService
    {
        public void TAdd(EntityLayer.Concrete.SuggestRecipe t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(EntityLayer.Concrete.SuggestRecipe t)
        {
            throw new NotImplementedException();
        }

        public EntityLayer.Concrete.SuggestRecipe TGetByCondition(Expression<Func<EntityLayer.Concrete.SuggestRecipe, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public EntityLayer.Concrete.SuggestRecipe TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<EntityLayer.Concrete.SuggestRecipe> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public List<EntityLayer.Concrete.SuggestRecipe> TGetListAll(Expression<Func<EntityLayer.Concrete.SuggestRecipe, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(EntityLayer.Concrete.SuggestRecipe t)
        {
            throw new NotImplementedException();
        }
    }
}
