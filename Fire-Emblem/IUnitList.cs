using Fire_Emblem_Common;
namespace Fire_Emblem;

public interface IUnitList
{
    void Add(Unit unit);
    void Remove(Unit unit);
    bool Contains(Unit unit);
    int Count { get; }
    Unit Get(int index);
    IEnumerable<Unit> GetAll();
}