namespace FinanceTracker.BOL.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
    }

    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
    }

    public class UpdateCategoryDto
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }

    public class CategorySummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
    }
}