using DoAn_Entity;

namespace DoAn_Service;

public interface IOrderInputService
{
    List<InputInvoice> GetList();
    int CountInventoryById(int id);
    List<InputInvoice> GetListInventory();

    InputInvoice GetById(int id);
    void AddProduct(InputInvoice invoice);
    void UpdateProduct(InputInvoice invoice);
    void Delete(int id);
}