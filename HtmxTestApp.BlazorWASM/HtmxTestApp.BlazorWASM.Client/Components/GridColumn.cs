using Microsoft.AspNetCore.Components;

namespace HtmxTestApp.BlazorWASM.Client.Components
{
    public class GridColumn<TItem>
    {
        /// <summary>
        /// The data field name of the item (e.g., "Name", "Price").
        /// </summary>
        public string Field { get; set; } = default!;

        /// <summary>
        /// The header/title of the column.
        /// </summary>
        public string Title { get; set; } = default!;

        /// <summary>
        /// Whether sorting is enabled for this column.
        /// </summary>
        public bool Sortable { get; set; }

        /// <summary>
        /// Whether filtering is enabled for this column.
        /// </summary>
        public bool Filterable { get; set; }

        /// <summary>
        /// RenderFragment for custom cell template.
        /// If set, this will override the default text-based cell content.
        /// </summary>
        public RenderFragment<TItem>? CellTemplate { get; set; }
    }
}
