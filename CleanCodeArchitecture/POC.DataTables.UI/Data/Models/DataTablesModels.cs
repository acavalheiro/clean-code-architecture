namespace POC.DataTables.UI.Data.Models
{
    public class DataTablesRequestModel
    {
        public int Draw { get; set; }          // Draw counter (for DataTables' internal use)
        public int Start { get; set; }         // Starting index for pagination
        public int Length { get; set; }        // Number of records to fetch per page (page size)
        public SearchModel Search { get; set; } // Global search parameter
        public List<OrderModel> Order { get; set; } // Sorting options
        public List<ColumnModel> Columns { get; set; } // Columns info
    }

    public class SearchModel
    {
        public string Value { get; set; }       // Search term entered by the user
        public bool Regex { get; set; }         // Whether the search term is a regular expression
    }

    public class OrderModel
    {
        public int Column { get; set; }         // Index of the column being sorted
        public string Dir { get; set; }         // Sorting direction: "asc" or "desc"
    }

    public class ColumnModel
    {
        public string Data { get; set; }        // Column name or data property
        public string Name { get; set; }        // Column name
        public bool Searchable { get; set; }    // Whether the column is searchable
        public bool Orderable { get; set; }     // Whether the column is orderable
        public SearchModel Search { get; set; } // Per-column search parameters
    }


    public class DataTablesResponseModel<T>
    {
        public int Draw { get; set; }              // Draw counter, passed back unchanged
        public int RecordsTotal { get; set; }      // Total number of records without filtering
        public int RecordsFiltered { get; set; }   // Total number of records after filtering
        public IEnumerable<T> Data { get; set; }          // The actual data to be displayed (the current page of records)
        public string Error { get; set; }          // Error message (if any)
    }
}
