using DoAn_Entity;

namespace DoAn_Service;

public interface IOrderOutputService
{
    List<InputInvoice> GetList();
    int CountInventoryById(int id);
    InputInvoice GetById(int id);
    void AddProduct(InputInvoice invoice);
    void UpdateProduct(InputInvoice invoice);
    void Delete(int id);
}