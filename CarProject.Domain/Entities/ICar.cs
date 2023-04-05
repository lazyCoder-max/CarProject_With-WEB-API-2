namespace CarProject.Domain.Entities
{
    public interface ICar
    {
        string Color { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        int YearMade { get; set; }
    }
}