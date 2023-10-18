using DavidTielke.PMA.CrossCutting.DataClasses;

namespace DavidTielke.PMA.Logic.PersonManagement;

public interface IPersonManager
{
    IQueryable<Person> GetAdults();
    IQueryable<Person> GetChildren();
}