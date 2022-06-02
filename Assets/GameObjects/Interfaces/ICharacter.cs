using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameObjects.Interfaces
{
    internal interface ICharacter: IGameObject
    {
        public void SetDamage(int damage);
        public void Update(ICharacterConfig config);
    }
}
