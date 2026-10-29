namespace SrpLab.RefactoredClasses;

public class XmlBatch
{
    public string WmsXmlBatch(string batchId, IReadOnlyList<(string Sku, int Allocated)> allocate)
    {
        // Integration contract with WMS — third reason to change.
        var parts = allocate.Select(a => $"<line sku=\"{a.Sku}\" qty=\"{a.Allocated}\" />");
        return $"<batch id=\"{batchId}\">{string.Join("", parts)}</batch>";
    }
}
