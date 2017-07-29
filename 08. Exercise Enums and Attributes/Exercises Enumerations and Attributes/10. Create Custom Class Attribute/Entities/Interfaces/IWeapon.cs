namespace _10.Create_Custom_Class_Attribute.Entities.Interfaces
{
    public interface IWeapon
    {
        string Name { get; }
        string Type { get; }
        string RarityType { get; }
        int MinDamage { get; }
        int MaxDamage { get; }
        int Sockets { get; }
        IGem[] Gems { get; }
        int BonusMinDamage { get; }
        int BonusMaxDamage { get; }

        void AddGem(int index, IGem gem);

        void RemoveGem(int targetSocket);

        void Print();
    }
}