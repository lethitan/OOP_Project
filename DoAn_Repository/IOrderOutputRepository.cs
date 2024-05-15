using DoAn_Entity;

namespace DoAn_Repository;

public interface IOrderOutputRepository
{
    List<OutputInvoice> GetList();
    OutputInvoice GetById(int id);
    void AddProduct(OutputInvoice invoice);
    void UpdateProduct(OutputInvoice invoice);
    void Delete(int id);
}