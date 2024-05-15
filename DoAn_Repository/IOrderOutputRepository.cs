using DoAn_Entity;

namespace DoAn_Repository;

public interface IOrderOutputRepository
{
    List<OutputInvoice> GetList();
    OutputInvoice GetById(int id);
    void AddInvoice(OutputInvoice invoice);
    void Delete(int id);
    void DeleteItem(int id, int invoiceId);
    OutputDetail GetDetailById(int detailId);
    OutputDetail UpdateOutputDetail(OutputDetail input, int invoiceId);
}