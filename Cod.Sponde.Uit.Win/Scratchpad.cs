/*using System;

namespace Cod.Sponde.Uit.Win
{
private class Scratchpad
{
private Scratchpad()
{
if (dgvFilterList.SelectedRows.Count > 0)
{
    Tag = (String)dgvFilterList.SelectedRows[0].Cells[4].Value;
    SelectedReportFilterId = Int32.Parse(dgvFilterList.SelectedRows[0].Cells[0].Value.ToString());
    DialogResult = DialogResult.OK;
    Close();
}
else if (dgvFilterList.SelectedCells.Count > 0)
{
    Tag = (String)dgvFilterList.Rows[dgvFilterList.SelectedCells[0].RowIndex].Cells[4].Value;
    SelectedReportFilterId = Int32.Parse(dgvFilterList.Rows[dgvFilterList.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
    DialogResult = DialogResult.OK;
    Close();
}
}
}
}

// Couldn't get StringWriter to serialise the object, so am rolling my own XML
StringBuilder xmlSb =
    new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<ArrayOfReportFilterItem xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\n");
foreach (ReportFilterItem rpi in result)
{
    xmlSb.Append("<ReportFilterItem>\n");
    xmlSb.Append(String.Format("<ParameterKey>{0}</ParameterKey>\n<ParameterValue>{1}</ParameterValue>\n",
        rpi.ParameterKey.ToString(), rpi.ParameterValue.ToString()));
    xmlSb.Append("</ReportFilterItem>\n");
}
xmlSb.Append("</ArrayOfReportFilterItem>");

try
{
    // This line replaces any symbols that may have got into the database before the Character Entity Reference fix.
    xmlString = xmlString.Replace(":<", ":&lt;").Replace(":>", ":&gt;").Replace(":<>", ":&lt;&gt;");
    StringReader sr = new StringReader(xmlString);
    var deserializer = new XmlSerializer(typeof(List<ReportFilterItem>));
    filterList = (List<ReportFilterItem>)deserializer.Deserialize(sr);
}
catch (Exception ex)
{
    //throw new ApplicationException(
    MessageBox.Show("The xml is not in a valid format.", "Infinity Report Criteria", MessageBoxButtons.OK, MessageBoxIcon.Error);
    return;
}

using (var sw = new StreamWriter(@"c:\test.xml"))
{
    var serializer = new XmlSerializer(typeof(List<ReportFilterItem>));
    serializer.Serialize(sw, result);
    sw.Close();
}

using (var sr = new StreamReader(@"c:\test.xml"))
{
    var deserializer = new XmlSerializer(typeof(List<ReportFilterItem>));
    filterList = (List<ReportFilterItem>)deserializer.Deserialize(sr);
    sr.Close()
}
// Serialise
// Deserialise
internal static DLLReportInfo GetStockAndSalesReportInfo() {
    DLLReportInfo result = new DLLReportInfo() {
        DateRequired = ReportDates.NoDates,
        DLLIndex = (int)ReportIndex.StockAndSales,
        MenuPath = "N,I",
        Parameters = new List<string>() {"sortcolumn"},
        Title = "Sales and Stock",
        StoredProcedure = "RCR_WildStockAndSales",
        FilterBy = new Dictionary<string, string>(),
        SortBy = new Dictionary<string, object>() { 
            { "Product Code", "Product Code" }, 
            { "Description", "Description" }, 
            { "Sold Units", "Qty Sold" }, 
            { "Retail Value", "Value Sold" } 
        },
        GroupBy = new List<string>() {
            "Supplier",
            "Branch",
            "Department"
         },
        FileName = "",
        SQLVersion = 9,
        SQLResource = "Triquestra.Reporting.ReportPack.Reports.RCR_WildStockAndSales.sql",
        ReportResource = "Triquestra.Reporting.ReportPack.Reports.RCR_WildStockAndSales.rpt",
        ReportFileName = "RCR_WildStockAndSales.rpt",                
        AllowLongSubtitle = true,               
    };
    return result;
}*/
/*private void btnTest_Click(object sender, EventArgs e)
{
    txtResult.Clear();
    txtResult.Text = "Testing the service...";
    backgroundWorker1.RunWorkerAsync(txtWsdlAddress.Text);
}

private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
{
    e.Result = TestWsdl(e.Argument as string);
}

private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
{
    txtResult.Text = e.Result as string;
}


private string TestWsdl(string url)
{
try
    {
        string serviceUrl = url.Replace("?wsdl", String.Empty);
        BasicHttpBinding myBinding = new BasicHttpBinding();

        EndpointAddress myEndpoint = new EndpointAddress(serviceUrl);

        //serviceClient = new InfinityWebIntegrationClient("BasicHttpBinding_IInfinityWebIntegration", serviceUrl);
        serviceClient = new InfinityWebIntegrationClient(myBinding, myEndpoint);

        string response = null;
        serviceClient.PullSystemInfo(out response);

        if (response == null)
        {
            response = "The service was found, but no response was returned. Please review the server side logs for more details.";
        }

        return response;
    }
    catch (Exception ex)
    {
        return ex.Message;
    }
    finally
    {
        if (serviceClient != null)
        {
            if (serviceClient.State != System.ServiceModel.CommunicationState.Closed)
            {
                serviceClient.Close();
            }
        }
    }
}*/