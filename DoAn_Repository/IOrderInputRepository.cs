using DoAn_Entity;

namespace DoAn_Repository;

public interface IOrderInputRepository
{
    List<InputInvoice> GetList();
    InputInvoice GetById(int id);
    void SaveList(List<InputInvoice> invoices);
    void AddInvoice(InputInvoice invoice);
    void Delete(int id);
    void DeleteItem(int id, int invoiceId);
    InputDetail GetDetailById(int detailId);
    InputDetail UpdateInputDetail(InputDetail input, int invoiceId);
}