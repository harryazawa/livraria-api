namespace livrariaAPIs.Models;

public class Produto
{
    public string ID { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }
    public string Categoria { get; set; }
    public string Img { get; set; }
}