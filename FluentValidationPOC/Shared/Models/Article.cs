namespace FluentValidationPOC.Shared.Models
{
    public class Article
    {
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        public ArticleStatus Status { get; set; }
    }


    public enum ArticleStatus
    {
        New,
        ReadyForWeb,
        Discontinued
    }
}
