using System.Text.Json.Serialization;

namespace lesson_3_1_5.Models
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Product
    {
        public Product(Guid id, string name, decimal cost, string description, string photoPath)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
            PhotoPath = photoPath;
        }

        /// <summary>
        /// Идентификатор товара
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Стоимость товара
        /// </summary>
        [JsonPropertyName("cost")]
        public decimal Cost { get; set; }

        /// <summary>
        /// Описание товара
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Фото
        /// </summary>
        [JsonPropertyName("photoPath")] 
        public string PhotoPath { get; set; } = "/img/image_file-32.png";

        /// <summary>
        /// Строковое представление товара
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"#{Id}: {Name} - {Cost} руб.";
        }
    }
}
