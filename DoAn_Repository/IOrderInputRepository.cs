using DoAn_Entity;

namespace DoAn_Repository;

public interface IOrderInputRepository
{
    List<InputInvoice> GetList();
    InputInvoice GetById(int id);
    void AddProduct(InputInvoice invoice);
    void UpdateProduct(InputInvoice invoice);
    void Delete(int id);
}