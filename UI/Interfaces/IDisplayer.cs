using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Interfaces
{
    public interface IDisplayer
    {
        void GenderSetter(Person person);
        void NameSetter(Person person);
        void SalarySetter(Person person);
        bool AnotherPerson();
    }
}
