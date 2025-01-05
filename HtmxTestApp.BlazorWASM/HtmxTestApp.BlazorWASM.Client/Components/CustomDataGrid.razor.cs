using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace HtmxTestApp.BlazorWASM.Client.Components
{
    public partial class CustomDataGrid<TItem> : ComponentBase
    {
        /// <summary>
        /// The source list of data to be displayed in the grid.
        /// </summary>
        [Parameter]
        public IEnumerable<TItem>? Data { get; set; }

        /// <summary>
        /// List of columns to display in the grid.
        /// </summary>
        [Parameter]
        public List<GridColumn<TItem>> Columns { get; set; } = new();

        /// <summary>
        /// Page size. If zero or negative, pagination is disabled.
        /// </summary>
        [Parameter]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Whether to display the filter row.
        /// </summary>
        [Parameter]
        public bool ShowFilterRow { get; set; } = true;

        protected int CurrentPage { get; set; } = 1;
        protected string? CurrentSortField { get; set; }
        protected bool SortAscending { get; set; } = true;

        // Internal dictionary to hold filter values
        protected Dictionary<string, string> filters = new();

        // For performance, we keep a filtered version of the data
        protected List<TItem> FilteredData { get; set; } = new();

        // This property slices the FilteredData for the current page
        protected IEnumerable<TItem> PagedData =>
            PageSize > 0
            ? FilteredData.Skip((CurrentPage - 1) * PageSize).Take(PageSize)
            : FilteredData;

        protected int TotalPages =>
            PageSize > 0
            ? (int)Math.Ceiling((double)FilteredData.Count / PageSize)
            : 1;

        protected bool CanGoPrev => CurrentPage > 1;
        protected bool CanGoNext => CurrentPage < TotalPages;

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            ApplyFilters(false);
        }

        protected void NextPage()
        {
            if (CanGoNext)
            {
                CurrentPage++;
            }
        }

        protected void PrevPage()
        {
            if (CanGoPrev)
            {
                CurrentPage--;
            }
        }

        protected void SortByColumn(GridColumn<TItem> column, bool ascending)
        {
            if (!column.Sortable) return;

            CurrentSortField = column.Field;
            SortAscending = ascending;
            SortAndFilterData();
        }

        /// <summary>
        /// Called when the user clicks 'Apply' button to filter.
        /// </summary>
        protected void ApplyFilters()
        {
            CurrentPage = 1;
            SortAndFilterData();
        }

        /// <summary>
        /// Sorts the data (if applicable) and applies filters.
        /// </summary>
        protected void SortAndFilterData()
        {
            if (Data == null)
            {
                FilteredData = new List<TItem>();
                return;
            }

            // 1. Filter
            var query = Data.AsQueryable();
            foreach (var filter in filters)
            {
                var fieldName = filter.Key;
                var filterValue = filter.Value?.ToLowerInvariant() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(filterValue)) continue;

                // Build Expression to filter items 
                query = query.Where(item =>
     (GetPropertyValue(item, fieldName).ToString().ToLowerInvariant())
         .Contains(filterValue)
 );
            }

            // 2. Sort
            if (!string.IsNullOrEmpty(CurrentSortField))
            {
                // Use reflection to sort by property name
                var prop = typeof(TItem).GetProperty(CurrentSortField,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (prop != null)
                {
                    query = SortAscending
                        ? query.OrderBy(item => prop.GetValue(item, null))
                        : query.OrderByDescending(item => prop.GetValue(item, null));
                }
            }

            FilteredData = query.ToList();
        }

        /// <summary>
        /// Applies or re-applies filtering without resetting the filter dictionary.
        /// For example, if data changed externally.
        /// </summary>
        protected void ApplyFilters(bool resetFilterValues = true)
        {
            if (resetFilterValues)
            {
                // Reset existing filters if desired
                foreach (var key in filters.Keys.ToList())
                {
                    filters[key] = string.Empty;
                }
            }

            CurrentPage = 1;
            SortAndFilterData();
        }

        /// <summary>
        /// A helper method to retrieve a property value by reflection for display or filtering.
        /// </summary>
        /// <param name="item">The data item.</param>
        /// <param name="propName">The property name to retrieve from the item.</param>
        /// <returns>The property value or null if not found.</returns>
        protected object? GetPropertyValue(TItem item, string propName)
        {
            var prop = typeof(TItem).GetProperty(propName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            return prop?.GetValue(item, null);
        }
    }
}